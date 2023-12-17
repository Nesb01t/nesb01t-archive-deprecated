<template>
	<view>
		<!-- 搜索框 -->
		<!--<u-search inputAlign="center" height="35" shape="square" :showAction="false" :animation="true"
			v-model="searchText" @search="onSearchInput()" @custom="onSearchInput()" @clear="clearTxet()"></u-search>
		<u-gap height="10" bgColor="#dedede"></u-gap> -->

		<view
			style="box-shadow: 0px 1px #cfcfcf; font-size: 22px; text-align: center; padding: 30rpx 0rpx; top: 0; position: fixed; z-index: 999; background-color: white; width: 100%;">
			同学列表
		</view>

		<!-- 学生索引列表 -->
		<view class="contact" style="margin-top: 120rpx">
			<u-index-list :index-list="indexList">
				<!-- A 到 Z 字母列表 -->
				<view v-for="(item, index) in itemArr">
					<!-- 字母标头 -->
					<u-index-item>
						<u-index-anchor :text="indexList[index]" v-if="item.length > 0" size="10px"></u-index-anchor>
					</u-index-item>

					<!-- 用户列表, item 即某个字母对应的用户 list -->
					<view class="list-cell" v-for="(cell, index) in item" :key="index"
						@click="getShowingUserInfo(cell.id)">
						<u-avatar style="margin-right: 10px;" shape="square" size="30" id="avatar"></u-avatar>
						{{ cell.name }}
					</view>
				</view>
			</u-index-list>
		</view>

		<!-- 用户信息 遮罩层 -->
		<clickshowinfo :userData="showingUserInfo" ref="userInfo"></clickshowinfo>
	</view>
</template>
<script>
	import pinyin from 'pinyin';
	import clickshowinfo from '../../components/clickShowinfo.vue';
	export default {
		data() {
			return {
				indexList: ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
					'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
				],
				userList: [],
				itemArr: [
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[],
					[]
				],

				searchText: '',
				showingUserInfo: {},
				studentnumber: '',
			};
		},
		mounted() {
			this.getUserList(); // 登录成功后获取用户列表
		},
		methods: {
			/**
			 * 获取用户列表
			 */
			async getUserList() {
				let that = this;
				await uni.request({
					url: 'http://101.43.107.183:3000/user/list',
					method: 'GET',
					success: res => {
						that.userList = res.data;
						that.itemArr = [
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[],
							[]
						];
						for (const user of that.userList) {
							that.pushUserToShowList(user)
						}
					}
				});
			},

			/**
			 * 将某个用户 ({id, name}) 载入 itemArr
			 * @param {Object} userCell
			 */
			pushUserToShowList(userCell) {
				const pinyinName = pinyin(userCell.name, {
					style: pinyin.STYLE_NORMAL
				}).join('');
				const upperstr = pinyinName.toUpperCase();
				const index = upperstr.charCodeAt(0) - 65;
				if (this.itemArr[index] !== undefined) {
					this.itemArr[index].push(userCell);
				}
			},

			/**
			 * 根据ID将某个学生载入 showingUserInfo
			 * @param {Object} id 学生ID
			 */
			getShowingUserInfo(id) {
				var that = this;
				uni.request({
					url: 'http://101.43.107.183:3000/user/info?id=' + id,
					method: 'GET',
					success(res) {
						that.showingUserInfo = res.data;
						that.$refs.userInfo.open();
					}
				})
			},
		},
		components: {
			clickshowinfo
		}
	};
</script>

<style lang="scss" scoped>
	.list-cell {
		display: flex;
		border-bottom: 1px solid #ccc;
		padding-right: 7px;
		width: 100%;
		padding: 10px 24rpx;
		overflow: hidden;
		color: #323233;
		font-size: 12px;
		line-height: 26px;
		background-color: #fff;
	}

	.item-tag u-icon {
		font-size: 14px;
	}
</style>