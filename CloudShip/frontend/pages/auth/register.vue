<template>
	<view>
		<u--input v-model="id" placeholder="请输入你的学号"></u--input>
		<u--input v-model="password" placeholder="请输入你的密码"></u--input>
		<button @click="handleRegister" type="primary">注册</button>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				id: '',
				password: ''
			};
		},
		methods: {
			handleRegister() {
				console.log(this.id, this.password);
				var that = this;
				uni.request({
					url: 'http://101.43.107.183:3000/auth/login',
					data: {
						id: this.id,
						password: this.password
					},
					method: 'POST',
					success(res) {
						console.log(res);
						console.log(res.statusCode);
						if (res.statusCode == 200) {
							console.log(1);
							uni.switchTab({
								url: "/pages/user-list/user-list",
							});
						}
					}
				});
			}
		}
	};
</script>

<style></style>
