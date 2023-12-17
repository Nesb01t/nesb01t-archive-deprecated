<template>
	<view>
		<Login v-if="!this.isLogin" @login="handleLogin"></Login>
		<view v-else>
			<!-- 主页面展示 -->
			<UserList ref="userList" v-if="this.Index==0"></UserList>
			<UserSelf v-if="this.Index==1" :id="this.userId"></UserSelf>

			<!-- 导航栏 -->
			<TabBar @changeIndex="getIndex"></TabBar>

			<!-- 用户信息填写 -->
			<popupForm :userId="this.userId" @finish="handleRegister"></popupForm>
		</view>
	</view>
</template>
<script>
	import Login from './auth/login.vue';
	import UserList from './user-list/user-list.vue';
	import UserSelf from './user-self/user-self.vue';
	import TabBar from './tabbar/tabbar.vue';
	import popupForm from '../components/popupform.vue'
	export default {
		data() {
			return {
				isLogin: false,
				userId: null,
				Index: 0,
				needMoreInformation: false,
			};
		},
		methods: {
			handleLogin(id) {
				this.userId = id;
				this.isLogin = true;
			},
			getIndex(index) {
				this.Index = index
			},
			toUserList() {
				this.index = 0;
			},
			toUserSelf() {
				this.index = 1;
			},
			handleRegister() {
				this.$refs.userList.getUserList()
			}
		},
		components: {
			popupForm,
			Login,
			UserList,
			UserSelf,
			TabBar,
		},
	};
</script>

<style></style>