<template>
	<view>
		<u-tabbar :fixed="true" :safeAreaInsetBottom="true" :value="value" @change="name => value = name">
			<u-tabbar-item class="bar" text="联系人" icon="home" @click="changeIndex(0)"></u-tabbar-item>
			<u-tabbar-item class="bar" text="我的" icon="account" @click="changeIndex(1)"></u-tabbar-item>
		</u-tabbar>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				value: 0,
				index: 0,
			}
		},
		methods: {
			changeIndex(index) {
				this.index = index
				this.$emit('changeIndex', this.index)
			},
		}
	}
</script>
<style scoped>
.bar {
	box-shadow: 0px -1px #cfcfcf;
}
</style>
