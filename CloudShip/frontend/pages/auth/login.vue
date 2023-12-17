<template>
	<view class="login">
		<!-- 头像 -->
		<u-avatar :src="avatarSrc" size="200rpx" shape="circle" style="margin: 0 100rpx;"></u-avatar>
		<view class="text-area">
			<text class="title">{{ helloTitle }}</text>
		</view>

		<!-- 输入表单 -->
		<view>
			<view style="display: flex;align-items: center;">
				学号
				<u--input class="inputer" type="number" placeholderStyle="#909399" placeholder="输入您的学号" border="bottom"
					v-model="userId"></u--input>
			</view>

			<view style="display: flex;align-items: center;">
				密码
				<u--input class="inputer" type="password" placeholderStyle="#909399" placeholder="输入您的密码"
					border="bottom" v-model="userPassword">
				</u--input>
			</view>

			<view style="display: flex;align-items: center; margin: 10px auto">
				记住密码
				<checkbox-group class="checkbox-group" @change="handleRemember">
					<checkbox value="remember"></checkbox>
				</checkbox-group>
			</view>
		</view>

		<!-- 提交按钮 -->
		<view class="btn-list">
			<view class="btn">
				<u-button @click="handleLogin" text="登录" size="large"></u-button>
			</view>
			<view class="btn">
				<u-button @click="openPopup" text="注册" size="large"></u-button>
			</view>
		</view>

		<!-- 覆盖层 -->
		<u-toast ref="uToast"></u-toast>
		<!-- 注册组件 -->
		<u-popup customStyle="
			padding-bottom: 1000px" closeable :show="popupShow" mode="top" @close="closePopup" @open="openPopup">
			<view>
				<input class="input" type="number" placeholderStyle="#909399" placeholder="请输入你的学号" v-model="userId" />
				<input class="input" type="password" placeholderStyle="#909399" placeholder="请输入你的密码"
					v-model="userPassword" />
				<u-button style="width: 150rpx;" @click="handleRegister" type="primary">注册</u-button>
			</view>
		</u-popup>
	</view>
</template>

<script>
	import Register from "./register.vue"
	export default {
		data() {
			return {
				avatarSrc: '/static/logo.png',
				helloTitle: '👋欢迎初次使用~',

				userId: '',
				userPassword: '',
				rememberPassword: false,
				firstLoginUser: false,

				popupShow: false,
			};
		},
		mounted() {
			var that = this;
			uni.getStorage({
				key: 'userId',
				success: res => {
					that.userId = res.data;
				}
			});
			uni.getStorage({
				key: 'userPassword',
				success: res => {
					that.userPassword = res.data;
				}
			});
			uni.getStorage({
				key: 'rememberPassword',
				success: res => {
					that.rememberPassword = res.data;
				}
			});
			if (this.userId != '') {
				this.firstLoginUser = false;
			}

			if (this.firstLoginUser) {
				this.helloTitle = "👋欢迎回来~"
			}
		},
		methods: {
			/**
			 * 登录接口
			 */
			postAuth() {
				uni.request({
					method: 'POST',
					url: 'http://101.43.107.183:3000/auth/login',
					data: {
						id: this.userId,
						password: this.userPassword
					},
					success: res => {
						if (res.statusCode == 400) {
							// 登录失败
							this.showError("登录失败, 密码错误");
						} else if (res.statusCode == 200) {
							// 登录成功
							this.$emit('login', this.userId)
							uni.setStorage({
								key: "userId",
								data: this.userId
							});
							uni.setStorage({
								key: "userPassword",
								data: this.userPassword
							});
							uni.setStorage({
								key: "rememberPassword",
								data: this.rememberPassword
							});
						}
					}
				});
			},
			showError(message) {
				this.$refs.uToast.show({
					message,
					type: 'error',
					duration: 1000
				})
			},
			handleLogin() {
				if (!this.userId) {
					this.showError("请输入您的学号")
					return;
				} else if (!this.userPassword) {
					this.showError("请输入您的密码")
					return;
				}
				this.postAuth()
			},
			handleRegister() {
				this.postAuth()
			},
			handleRemember(e) {
				if (e.detail.value.length == 1) {
					this.rememberPassword = true
				} else {
					this.rememberPassword = false
				}
			},
			openPopup() {
				this.popupShow = true
			},
			closePopup() {
				this.popupShow = false
			},
		},
		components: {
			Register
		}
	};
</script>

<style scoped>
	.login {
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: center;
		padding: 200rpx 0;
	}

	.btn-list {
		display: flex;
		flex-direction: row;
		width: 400rpx;
		margin-top: 15px;
	}

	.btn {
		width: 40%;
		margin: auto;
	}

	.text-area {
		display: flex;
		justify-content: center;
		margin: 40rpx 0;
	}

	.title {
		font-size: 36rpx;
		color: #8f8f94;
	}

	.inputer {
		box-shadow: 0 0 2px rgba(0, 0, 0, 0.5), 0 0 0 1px transparent;
		border-radius: 15px;
		border-color: black;
		padding: 0.4vw;
		max-width: 190px;

		margin: 20rpx 12px;
	}

	.input:hover {
		box-shadow: 0 0 3px rgba(0, 0, 0, 0.5), 0 0 0 1px transparent;
		border-radius: 15px;
		border-color: black;
	}

	.checkbox-group {
		margin-left: 10px;
	}
</style>