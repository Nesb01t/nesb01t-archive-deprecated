<template>
	<view>
		<view style="padding: 25px; text-align: center; font-size: 22px;">个人中心</view>
		<u-cell-group>
			<!-- <u-cell title="头像">
					<view slot="value">
						<image :src="userData.picUrl" style="width: 100rpx; height: 100rpx;"></image>
					</view>
				</u-cell> -->
			<u-cell title="姓名:" :value="getItem('name')"></u-cell>
			<u-cell title="班级:" :value="getItem('class')"></u-cell>
			<u-cell title="学号:" :value="getId()"></u-cell>
			<u-cell title="电话:" :value="getItem('phone')"></u-cell>
			<u-cell title="生日:" :value="getItem('birthday')"></u-cell>
			<u-cell title="简介:" :value="getItem('introduction')"></u-cell>
		</u-cell-group>
	</view>
</template>
<script>
	export default {
		props: ["id"],
		data() {
			return {
				userData: {
					picUrl: '../../image/active/contact-1.png',
					id: '',
					states: {
						name: '',
						sex: '',
						class: '',
						phone: '',
						birthday: '',
						introduction: ''
					}
				}
			};
		},
		methods: {
			getUserInfo() {
				uni.request({
					url: 'http://101.43.107.183:3000/user/info?id=' + this.userData.id,
					method: 'GET',
					success: res => {
						this.userData.id = res.data.id;
						this.userData.states = res.data.states;
					},
					fail: error => {}
				});
			},
			getItem(attr) {
				if (this.userData === undefined) return "N/A"
				if (this.userData.states === undefined) return "N/A"
				if (this.userData.states[attr] == "") return "N/A"
				return this.userData.states[attr]
			},
			getId() {
				return this.userData.id
			}
		},
		mounted() {
			this.userData.id = this.id
			this.getUserInfo();
		}
	};
</script>

<style></style>