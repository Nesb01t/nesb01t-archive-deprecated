<template>
	<view>
		<u-popup :show="this.show" @close="close" mode="center"
			customStyle="width:300px;height=700rpx; padding:25px 20px">
			<view style="margin: 15px; font-weight: bold;">CloudShip</view>
			<u-cell-group>
				<!-- <u-cell title="头像:" value=""></u-cell> -->
				<u-cell title="姓名:" :value="getItem('name')"></u-cell>
				<u-cell title="班级:" :value="getItem('class')"></u-cell>
				<u-cell title="学号:" :value="getId()"></u-cell>
				<u-cell title="电话:" :value="getItem('phone')"></u-cell>
				<u-cell title="生日:" :value="getItem('birthday')"></u-cell>
				<u-cell title="简介:" :value="getItem('introduction')"></u-cell>
			</u-cell-group>
		</u-popup>
	</view>
</template>
<script>
	export default {
		props: ['userData'],
		mounted() {},
		data() {
			return {
				show: false
			};
		},
		methods: {
			open() {
				this.show = true;
			},
			close() {
				this.show = false;
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
		computed: {}
	};
</script>