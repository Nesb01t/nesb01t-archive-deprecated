<template>
	<view>
		<u-popup :show="show" mode="center" :round="10" customStyle="width:300px;height=700px; padding:15px 20px;">
			<u--form :rules="rules" :model="model">
				<!-- 头像 -->
				<view>当前为测试版, 头像功能正在开发中</view>
				<!-- <uni-forms-item label="CloudShip" prop="user.picurl" borderBottom>
					<u--input>
						<u-upload :fileList="fileList1" @afterRead="afterRead" @delete="deletePic" name="1" multiple
							:maxCount="10"></u-upload>
					</u--input>
				</uni-forms-item> -->

				<!-- 姓名栏 -->
				<u-form-item label="学号" prop="user.name" borderBottom>
					<u--input type="text" disabledColor="#ffffff" disabled :placeholder="this.userId">
					</u--input>
				</u-form-item>

				<!-- 姓名 -->
				<u-form-item label="姓名" borderBottom>
					<u--input type="text" disabledColor="#ffffff" placeholder="请输入姓名" v-model="model.user.states.name">
					</u--input>
				</u-form-item>

				<!-- 班级 -->
				<u-form-item label="班级" borderBottom>
					<u--input type="text" disabledColor="#ffffff" placeholder="请输入班级" v-model="model.user.states.class">
					</u--input>
				</u-form-item>

				<!-- 性别 -->
				<u-form-item label="性别" borderBottom @click="isSexshow = true"
					customStyle="width:300px;height=700px; padding:15px 0px">
					<u--input type="text" disabled disabledColor="#ffffff" placeholder="  请选择性别" border="none"
						v-model="model.user.states.sex"></u--input>
					<u-icon slot="right" name="arrow-right"></u-icon>
				</u-form-item>

				<!-- 生日 -->
				<u-form-item label="生日" borderBottom @click="isBirthdayShow = true"
					customStyle="width:300px;height=700px; padding:15px 0px">
					<u--input type="text" disabled disabledColor="#ffffff" placeholder="  请选择生日" border="none"
						v-model="model.user.states.birthday"></u--input>
					<u-icon slot="right" name="arrow-right"></u-icon>
				</u-form-item>

				<!-- 联系方式 -->
				<u-form-item label="TEL" borderBottom prop="user.phone" bordeeBottom
					customStyle="width:300px;height=700px; padding:15px 0px">
					<u--input type="text" disabledColor="#ffffff" placeholder="  请输入手机号" border="none"
						v-model="model.user.states.phone"></u--input>
				</u-form-item>

				<!-- 简介 -->
				<u-form-item label="简介" bordeeBottom customStyle="width:300px;height=700px; padding:15px 0px">
					<u--input type="text" disabledColor="#ffffff" placeholder="  不低于三个字" border="none"
						v-model="model.user.states.introduction"></u--input>
				</u-form-item>

				<view style="display: flex; margin: 20px; color: gray;">初次使用，请完善您的个人信息~</view>
				<!-- 提交按钮组 -->
				<view style="display: flex; margin: 20px;">
					<u-button type="error" text="重置" @click="reRegister" style="width: 40%;"></u-button>
					<u-button type="primary" text="保存" @click="postUpdate" style="width: 40%;"></u-button>
				</view>

				<!-- 性别遮罩层 -->
				<u-action-sheet :show="isSexshow" :actions="actions" title="请选择性别" @close="isSexshow = false"
					@select="handleSexSelect"></u-action-sheet>

				<!-- 生日遮罩层 -->
				<u-datetime-picker :show="isBirthdayShow" mode="date" :minDate="minDate" :maxDate="maxDate"
					title="请选择生日" closeOnClickOverlay @close="isBirthdayShow = false" @cancel="isBirthdayShow = false"
					@confirm="handleBirthdayConfirm"></u-datetime-picker>
					
				<u-toast ref="uToast"></u-toast>
			</u--form>
		</u-popup>
	</view>
</template>

<script>
	export default {
		props: ["userId"],
		data() {
			return {
				show: true,
				isBirthdayShow: false,
				isSexshow: false,
				minDate: null,
				maxDate: null,
				fileList1: [],
				model: {
					user: {
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
				},
				actions: [{
						name: '男'
					},
					{
						name: '女'
					}
				],
				rules: {
					'user.name': {
						require: true,
						message: '姓名必须是中文',
						trigger: ['change', 'blur'],
						pattern: /^[\u4E00-\u9FA5]{2,10}$/
					},
					'user.phone': {
						required: true,
						message: '请输入正确的手机号',
						trigger: ['change', 'blur'],
						pattern: /^(13[0-9]|14|15[0-35-9]|16|17[0-8]|18[0-9]|19[0-35-9])\d{8}$/
					},
					'user.introduction': {
						min: 3,
						message: '不低于三个字',
						trigger: ['change', 'blur'],
						pattern: /^[0-9a-zA-Z]*$/g,
						transform(value) {
							return String(value);
						}
					}
				}
			};
		},
		methods: {
			close() {
				this.show = false;
			},

			// 性别选择
			handleSexSelect(e) {
				this.model.user.states.sex = e.name;
			},

			// 生日确定
			handleBirthdayConfirm(e) {
				this.setBirthday(e.value);
				this.isBirthdayShow = false;
			},

			addZero(num) {
				if (parseInt(num) < 10) {
					num = '0' + num;
				}
				return num;
			},
			formatMsToDate(ms) {
				var oDate = new Date(ms),
					oYear = oDate.getFullYear(),
					oMonth = oDate.getMonth() + 1,
					oDay = oDate.getDate(),
					oTime = oYear + '-' + this.addZero(oMonth) + '-' + this.addZero(oDay) + ' ';
				this.model.user.states.birthday = oTime;
			},
			setBirthday(ticks) {
				this.formatMsToDate(ticks);
			},
			reRegister() {
				(this.model.user.states.name = ''), (this.model.user.states.sex = ''), (this.model.user.states.birthday = '');
				(this.model.user.states.phone = ''), (this.model.user.states.address = ''), (this.model.user.states.introduction = '');
			},

			/**
			 * 完成用户信息填写
			 */
			postUpdate() {
				if(!this.checkIfFormComplete()) {
					this.$refs.uToast.show({
						message: "请将信息填写完整~",
						type: 'error',
						duration: 1000
					})
					return
				}
				uni.request({
					method: 'POST',
					url: 'http://101.43.107.183:3000/user/update',
					data: {
						id: this.userId,
						states: this.model.user.states
					},
					success: e => {
						this.$emit('finish')
					}
				});
				this.close();
			},
			/**
			 * 获取当前用户信息, 自动填充到表单
			 */
			getRetailUserInfo() {
				uni.request({
					method: 'GET',
					url: 'http://101.43.107.183:3000/user/info?id=' + this.userId,
					success: e => {
						this.model.user.states = e.data.states;
					}
				});
			},
			// 检查是否完整
			checkIfFormComplete() {
				if (this.model.user.states.name != '' && this.model.user.states.sex != '' &&
					this.model.user.states.class != '' && this.model.user.states.phone != '' && this.model.user.states
					.birthday != '' && this.model.user.states.introduction != '') {
					return true;
				} else {
					return false;
				}
			}
		},
		mounted() {
			this.minDate = 852077000000;
			this.maxDate = Date.parse(new Date());
			this.getRetailUserInfo()
		}
	};
</script>

<style></style>