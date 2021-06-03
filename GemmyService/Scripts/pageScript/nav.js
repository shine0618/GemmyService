Vue.component('langu-a', {
    data: function () {
        return {
            data: 'aaaa',
        }
    },
    props: ['url', 'text', 'languCode'],
    template: ' <a :href="url"v-on:click="incrementHandler">{{text}}</a>',
    methods: {
        incrementHandler: function () {
            this.$emit('increment')
        }
    },
})



var nav_langu_box = new Vue({
    el: '#nav_langu_box',
    data() {
        var checkUsername = (rule, value, callback) => {
            const mailReg = /^([a-zA-Z0-9_-])+@@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
            if (!value) {
                return callback(new Error('邮箱不能为空'))
            }
            setTimeout(() => {
                if (mailReg.test(value)) {
                    callback()
                } else {
                    callback(new Error('请输入正确的邮箱格式'))
                }
            }, 100)

        };
        var validatePass = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入密码'));
            } else {
                if (this.ruleForm.checkPass !== '') {
                    this.$refs.ruleForm.validateField('checkPass');
                }
                callback();
            }
        };
        var validatePass2 = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleForm.pass) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        var validretrieveUsername = (rule, value, callback) => {
            const mailReg = /^([a-zA-Z0-9_-])+@@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
            if (!value) {
                return callback(new Error('不能为空'))
            }
            setTimeout(() => {
                if (mailReg.test(value)) {
                    callback();
                } else {
                    callback(new Error('请输入正确的邮箱格式'));
                }
            }, 100)

        };
        var validnewPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入密码'));
            } else {
                if (this.ruleRetrieve.checkNewPassword !== '') {
                    this.$refs.ruleRetrieve.validateField('checkNewPassword');
                }
                callback();
            }
        };
        var validcheckNewPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入密码'));
            } else if (value !== this.ruleRetrieve.newPassword) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        var validcode = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('验证码为空!'));
            } else {
                callback();
            }
        };
        return {
            defaultLanguage: '',
            defaultLanguageCode: '',
            list: null,
            drawer: true,
            dialogVisible_forget: false,
            dialogVisible_use: false,
            ruleLoginForm: {
                pass: '',
                checkPass: '',
                username: ''
            },
            ruleRegisterForm: {
                pass: '',
                retrieveUsername: '',
                checkPass: '',
                username: ''
            },
            ruleRetrieve: {

                code: '',
                newPassword: '',
                checkNewPassword: '',
                retrieveUsername: '',
            },
            rules: {
                pass: [
                    { validator: validatePass, trigger: 'blur' }
                ],
                checkPass: [
                    { validator: validatePass2, trigger: 'blur' }
                ],
                username: [
                    { validator: checkUsername, trigger: 'blur' },
                    //{ type: 'email', message: '请输入正确的邮箱地址', trigger: 'blur'}
                ]
            },
            rulesRetrieve: {
                retrieveUsername: [
                    { validator: validretrieveUsername, trigger: 'blur' },
                ],
                code: [
                    { validator: validcode, trigger: 'blur' },
                ],
                newPassword: [
                    { validator: validnewPassword, trigger: 'blur' },
                ],
                checkNewPassword: [
                    { validator: validcheckNewPassword, trigger: 'blur' },
                ]
            }
        }


    },
    // 在 `methods` 对象中定义方法
    methods: {


        ChanggeLangu: function (langcode) {
            this.$http({           //调用接口
                method: 'POST',
                url: "/JCSelectionLanguage/ajaxChanggelangu",
                params: {
                    keys: langcode,
                }
            }).then(function (response) {  //接口返回数据
                location.reload();
            }, function (error) {
            })
        },
        initNav: function (event) {
            
            //var CustomLang = '';
            ////如果客户语言
            //if (CustomLang == 'default') {
               
            //    this.defaultLanguageCode = lang;
            //}
            //else {
            //    this.defaultLanguageCode = CustomLang;
            //}
            var lang = navigator.language || navigator.userLanguage;//常规浏览器语言和IE浏览器
            lang = lang.substr(0, 2);//截取lang前2位字符
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelectionLanguage/GetLanguagesDetail",
                params: {
                    keys: '123',
                    code: this.defaultLanguageCode,
                    pagecode: lang,
                }
            }).then(function (response) {  //接口返回数据
                this.defaultLanguage = response.body.LanguageShortDesript;
                this.defaultLanguageCode = response.body.LanguageCode;
            }, function (error) {

                    console.log(error);
            })



        },

        initlangubox: function (event) {
          
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelectionLanguage/GetLanguages",
                params: {
                    keys: '123',
                }
            }).then(function (response) {  //接口返回数据
              //  console.log(response);
                this.list = response.body;
            }, function (error) {
                    console.log(error);
            })
        },

        changeState: function (drawer) {
            this.drawer = !drawer;
        },
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    alert('submit!');
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },
        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

    }
});
nav_langu_box.initNav();
nav_langu_box.initlangubox();