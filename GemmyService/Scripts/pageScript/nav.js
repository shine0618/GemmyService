﻿Vue.component('langu-a', {
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
const TIME_COUNT = 60;


var nav_langu_box = new Vue({
    el: '#nav_langu_box',
    data() {
        var checkUsername = (rule, value, callback) => {
            const mailReg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
            if (!value) {
                return callback(new Error('DL邮箱不能为空'))
            }
            setTimeout(() => {
                if (mailReg.test(value)) {
                    callback()
                } else {
                    callback(new Error('DL请输入正确的邮箱格式'))
                }
            }, 100)

        };
        var validatePass = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('DL请输入密码'));
            } else {
                callback();
            }
        };

        var validretrieveUsername = (rule, value, callback) => {
            const mailReg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
            if (!value) {
                return callback(new Error('CZ邮不能为空'))
            }
            setTimeout(() => {
                if (mailReg.test(value)) {
                    callback();
                } else {
                    callback(new Error('CZ请输入正确的邮箱格式'));
                }
            }, 100)

        };
        var validnewPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('CZ请输入密码'));
            } else {
                if (this.ruleRetrieve.retrievecheckPassword !== '') {
                    this.$refs.ruleRetrieve.validateField('retrievecheckNewPassword');
                }
                callback();
            }
        };
        var validcheckNewPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('CZ请再次输入密码'));
            } else if (value !== this.ruleRetrieve.retrievePassword) {
                callback(new Error('CZ两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        var validcode = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('CZ验证码为空!'));
            } else {
                callback();
            }
        };
        var registerUsername = (rule, value, callback) => {
            const mailReg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/
            if (!value) {
                return callback(new Error('ZC不能为空'))
            }
            setTimeout(() => {
                if (mailReg.test(value)) {
                    callback();
                } else {
                    callback(new Error('ZC请输入正确的邮箱格式'));
                }
            }, 100)

        };
        var registerPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('ZC请输入密码'));
            } else {
                if (this.ruleRegisterForm.registercheckPass !== '') {
                    this.$refs.ruleRegisterForm.validateField('registercheckPass');
                }
                callback();
            }
        };
        var registercheckPassword = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('ZC请再次输入密码'));
            } else if (value !== this.ruleRegisterForm.registerpass) {
                callback(new Error('ZC两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        var registercode = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('ZC验证码为空!'));
            } else {
                inputregistercode = value;
                callback();
            }
        };
        var registername = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('ZC名或姓为空!'));
            } else {
                callback();
            }
        };
        var resetloginoldpsd = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('旧密码为空!'));
            } else {               
                callback();
            }
        };
        var resetloginnewpsd = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请输入新密码'));
            } else {
                if (this.resetPasswordLogin.newPassword !== '') {
                    this.$refs.resetPasswordLogin.validateField('checkNewPassword');
                }
                callback();
            }
        };
        var resetloginchecknewpsd = (rule, value, callback) => {
            if (value === '') {
                callback(new Error('请再次输入新密码'));
            } else if (value !== this.resetPasswordLogin.newPassword) {
                callback(new Error('两次输入密码不一致!'));
            } else {
                callback();
            }
        };
        return {
            beginClientX: 0,
            /*距离屏幕左端距离*/
            mouseMoveStata: false,
            /*触发拖动状态 判断*/
            maxwidth: 258,
            /*拖动最大宽度，依据滑块宽度算出来的*/
            confirmWords: '拖动滑块验证',
            /*滑块文字*/
            confirmSuccess: false, /*验证成功判断*/
            defaultLanguage: '',
            defaultLanguageCode: '',
            loginEmail:'',
            list: null,
            drawer: false,
            dialogVisible_forget: false,
            dialogVisible_use: false,
            inputregistercode: '',
            isregister: false,
            islogin: false,
            isReset: false,
            count: '',
            registershow: true,
            show: true,
            timer: null,
            isLoginCheck: true,
            logincode: '',
            isSuccess: false,
            ruleLoginForm: {
                pass: '',
                code: '',
                username: ''
            },
            ruleRegisterForm: {
                registerpass: '',
                registercode: '',
                registercheckPass: '',
                registerusername: '',
                registerfirstname: '',
                registerlastname: ''
            },
            ruleRetrieve: {
                retrievecode: '',
                retrievePassword: '',
                retrievecheckPassword: '',
                retrieveUsername: '',
            },
            resetPasswordLogin: {
                oldPassword: '',
                newPassword: '',
                checkNewPassword: '',
            },
            rules: {
                pass: [
                    { validator: validatePass, trigger: 'blur' }
                ],
                code: [{ required: true }],
                username: [
                    { validator: checkUsername, trigger: 'blur' },
                    //{ type: 'email', message: '请输入正确的邮箱地址', trigger: 'blur'}
                ]
            },
            rulesRegister: {
                registerpass: [{ validator: registerPassword, trigger: 'blur' }],
                registercode: [{ validator: registercode, trigger: 'blur' }],
                registerusername: [{ validator: registerUsername, trigger: 'blur' }],
                registercheckPass: [{ validator: registercheckPassword, trigger: 'blur' }],
                registerfirstname: [{ validator: registername, trigger: 'blur' }],
                registerlastname: [{ validator: registername, trigger: 'blur' }]
            },
            rulesRetrieve: {
                retrieveUsername: [
                    { validator: validretrieveUsername, trigger: 'blur' },
                ],
                retrievecode: [
                    { validator: validcode, trigger: 'blur' },
                ],
                retrievePassword: [
                    { validator: validnewPassword, trigger: 'blur' },
                ],
                retrievecheckPassword: [
                    { validator: validcheckNewPassword, trigger: 'blur' },
                ]
            },
            rulesresetPasswordLogin: {
                oldPassword: [{ validator: resetloginoldpsd, trigger: 'blur' }],
                newPassword: [{ validator: resetloginnewpsd, trigger: 'blur' }],
                checkNewPassword: [{ validator: resetloginchecknewpsd, trigger: 'blur' }],
            },
            infoDataForm_contact: [

                {
                    'id': 100,
                    'menuName': '电子邮箱：renc@jiecang.com',
                    'icon': 'el-icon-message',
                },
                {
                    'id': 103,
                    'menuName': '联系方式  +86-0575-86287989',
                    'icon': 'el-icon-phone',
                }
            ],
            infoDataForm1: [
                {
                    'id': 100,
                    'menuName': '电子邮箱',
                    'icon': 'el-icon-message',
                },
                {
                    'id': 101,
                    'menuName': '名称',
                    'icon': 'el-icon-postcard',
                },
                {
                    'id': 102,
                    'menuName': '性别',
                    'icon': 'el-icon-s-custom',
                },
                {
                    'id': 103,
                    'menuName': '联系方式',
                    'icon': 'el-icon-phone',
                }
            ],
            infoDataForm2:
                [{
                    'id': 200,
                    'menuName': '公司名称',
                    'icon': 'el-icon-office-building',
                },
                {
                    'id': 201,
                    'menuName': '公司地址（街道）',
                    'icon': 'el-icon-location',
                },
                {
                    'id': 202,
                    'menuName': '公司邮编及详细地址',
                    'icon': 'el-icon-location',
                },
                {
                    'id': 203,
                    'menuName': '公司地区',
                    'icon': 'el-icon-map-location',
                },
                {
                    'id': 204,
                    'menuName': '公司官网',
                    'icon': 'el-icon-link',
                },],
            infoDataForm: [
                {
                    'id': 1,
                    'menuName': '个人信息',                   
                    'children': [
                        {
                            'id': 100,
                            'menuName': '电子邮箱',
                            'icon': 'el-icon-message',                           
                        },
                        {
                            'id': 101,
                            'menuName': '名称',
                            'icon': 'el-icon-postcard',                            
                        },
                        {
                            'id': 102,
                            'menuName': '性别',
                            'icon': 'el-icon-s-custom', 
                        },
                        {
                            'id': 103,
                            'menuName': '联系方式',
                            'icon': 'el-icon-phone', 
                        }
                    ]
                },
                {
                    'id': 2,
                    'menuName': '公司信息',
                    'children': [
                        {
                            'id': 200,
                            'menuName': '公司名称',
                            'icon': 'el-icon-office-building',
                        },
                        {
                            'id': 201,
                            'menuName': '公司地址（街道）',
                            'icon': 'el-icon-location',
                        },
                        {
                            'id': 202,
                            'menuName': '公司邮编及详细地址',
                            'icon': 'el-icon-location',
                        },
                        {
                            'id': 203,
                            'menuName': '公司地区',
                            'icon': 'el-icon-map-location',
                        },
                        {
                            'id': 204,
                            'menuName': '公司官网',
                            'icon': 'el-icon-link',
                        },
                    ]
                },
                {
                    'id': 3,
                    'menuName': '设置',
                    'children': [
                        {
                            'id': 300,
                            'menuName': '1',
                            'icon': 'el-icon-s-tools',
                        },
                    ]
                },
                {
                    'id': 4,
                    'menuName': '修改密码',
                    'children': [
                        {
                            'id': 400,
                            'menuName': '旧密码',
                            'icon': 'el-icon-lock',
                        },
                        {
                            'id': 401,
                            'menuName': '新密码',
                            'icon': 'el-icon-key',
                        },
                        {
                            'id': 402,
                            'menuName': '确认密码',
                            'icon': 'el-icon-key',
                        },
                        {
                            'id': 403,
                            'menuName': '修改',
                        },
                    ]
                },
            ],
            defaultProps: {
                children: 'children',
                label: 'menuName'
            },
            activeNames: ['1'],
            
        }
    },
    mounted() {
        $('body').on('mousemove', (e) => {
            //拖动，这里需要用箭头函数，不然this的指向不会是vue对象 
            if (this.mouseMoveStata) {
                var width = e.clientX - this.beginClientX;
                if (width > 0 && width <= this.maxwidth) {
                    $(".handler").css({
                        'left': width
                    });
                    $(".drag_bg").css({
                        'width': width
                    });
                } else if (width > this.maxwidth) {
                    this.successFunction();
                }
            }
        });
        $('body').on('mouseup', (e) => {
            //鼠标放开 
            this.mouseMoveStata = false;
            var width = e.clientX - this.beginClientX;
            if (width < this.maxwidth) {
                $(".handler").css({
                    'left': 0
                });
                $(".drag_bg").css({
                    'width': 0
                });
            }
        })

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
            
            this.loginEmail = GetLoginUsername();
                      
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
                console.log(response);
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
        register(username, pass, code, checkPass, firstname, lastname) {   
            
            if (username != '' && pass != '' && code != '' && checkPass != '' && firstname != '' && lastname != '') {
                this.$http({           //调用接口
                    method: 'POST',
                    url: "/JCAccount/Register",
                    params: {
                        email: username,
                        password: pass,
                        firstname: firstname,
                        lastname: lastname,
                        code: inputregistercode
                    }
                }).then(function (response) {  //接口返回数据
                    //  console.log(response);
                    this.issuccess = response.body;
                    console.log(response.body);
                    if (response.body.isRegister == true) {
                        this.$notify({
                            message: '注册成功',
                            type: 'success'
                        });
                        this.resetForm(ruleRegisterForm);
                        window.location = "/JCSelection/PersonInfo?email=" + username + "&name=" + firstname + " " + lastname;
                    }
                    else {
                        this.$notify.error('注册失败');
                    }
                }, function (error) {
                    console.log(error);
                })
            }
            else {
                this.$notify.error('信息未完善');
            }
        },
        login(email, password, confirmSuccess, isLoginCheck) {
            if (email != '' && password != '') {
                if (isLoginCheck == false) {
                    this.$http({           //调用接口
                        method: 'GET',
                        url: "/JCAccount/Login",
                        params: {
                            email: email,
                            password: password,
                        }
                    }).then(function (response) {  //接口返回数据
                        console.log(response.body);
                        if (response.body == null) {
                            this.$notify.error('登录失败');
                        }
                        else {
                            this.islogin = response.body;

                            if (this.islogin == false) {
                                isLoginCheck = true;
                            }
                            if (response.body.CanLogin == true) {
                                
                                location.reload();
                                this.$notify({
                                    message: '登录成功',
                                    type: 'success'
                                });
                            }
                        }
                        
                        
                    }, function (error) {
                        console.log(error);
                    })
                }
                else if (isLoginCheck == true && confirmSuccess == true) {
                    this.$http({           //调用接口
                        method: 'GET',
                        url: "/JCAccount/Login",
                        params: {
                            email: email,
                            password: password,
                        }
                    }).then(function (response) {  //接口返回数据
                        console.log(response.body);
                       // this.islogin = response.body;

                        if (response.body.CanLogin == true) {
                            location.reload();
                            
                            this.$notify({
                                message: '登录成功' ,
                                type: 'success'
                            });
                        }
                        else if (response.body.NoPassword) {
                            this.$notify.error('密码错误');
                        }
                        else {
                            this.$notify.error('账号错误');
                        }
                     //   console.log(response);
                        if (this.islogin == false) {
                            isLoginCheck = true;
                            
                        }

                    }, function (error) {
                        console.log(error);
                    })
                }
                
            }

        },
        LoginOut() {
            var emailaddress = '';
            this.$http({           //退出登录
                method: 'GET',
                url: "/JCAccount/LoginOut",
                params: {
                    emailaddress: emailaddress ,
                }
            }).then(function (response) {  //接口返回数据
                //  console.log(response);
                //  this.registercode = response.body;
                console.log(response);
                if (response.body.LoginOut == true) {
                    console.log('reload');
                    location.reload();
                    this.$notify({
                        message: '登出成功',
                        type: 'success'
                    });
                }

            }, function (error) {
                console.log(error);
            })
        },
        sendEmail(emailaddress) {
            if (emailaddress != '') {
                if (!this.timer) {
                    this.count = TIME_COUNT;
                    this.registershow = false;
                    this.timer = setInterval(() => {
                        if (this.count > 0 && this.count <= TIME_COUNT) {
                            this.count--;
                        } else {
                            this.registershow = true;
                            clearInterval(this.timer);
                            this.timer = null;
                        }
                    }, 1000)
                }

                this.$http({           //调用接口
                    method: 'GET',
                    url: "/JCAccount/SendRegisterEmail",
                    params: {
                        emailaddress: emailaddress,
                    }
                }).then(function (response) {  //接口返回数据
                    //  console.log(response);
                    //  this.registercode = response.body;
                    if (response.body != null) {
                        this.$notify({
                            message: '注册邮件发送成功',
                            type: 'success'
                        });
                    }
                    else {
                        this.$notify.error('注册邮件发送失败');
                    }
                    console.log(response);
                }, function (error) {
                    console.log(error);
                })

            }
        },
        sendResetEmail(emailaddress) {
            if (emailaddress != '') {
                if (!this.timer) {
                    this.count = TIME_COUNT;
                    this.show = false;
                    this.timer = setInterval(() => {
                        if (this.count > 0 && this.count <= TIME_COUNT) {
                            this.count--;
                        } else {
                            this.show = true;
                            clearInterval(this.timer);
                            this.timer = null;
                        }
                    }, 1000)


                    this.$http({           //调用接口
                        method: 'GET',
                        url: "/JCAccount/SendResetEmail",
                        params: {
                            emailaddress: emailaddress,
                        }
                    }).then(function (response) {  //接口返回数据
                        //  console.log(response);
                        this.retrievecode = response.body;
                        if (response.body != null) {
                            this.$notify({
                                message: '重置密码邮件发送成功',
                                type: 'success'
                            });
                        }
                        else {
                            this.$notify.error('重置密码邮件发送失败');
                        }
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    })
                }

            }
        },
        reset(email, password, code) {
            if (email != '' && password != '' && code != '') {
                if (email != '') {
                    this.$http({           //调用接口
                        method: 'POST',
                        url: "/JCAccount/Resetpassword",
                        params: {
                            email: email,
                            newpassword: password,
                            code: code
                        }
                    }).then(function (response) {  //接口返回数据
                        //  console.log(response);
                        this.isReset = response.body;
                        if (response.body == true) {
                            this.$notify({
                                message: '密码已重置',
                                type: 'success'
                            });
                        }
                        else {
                            this.$notify.error('密码未重置');
                        }
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    })
                }
            }

        },
        resetLogin(email, oldpassword,newpassword) {
            if (email != '' && oldpassword != '' && newpassword != '') {
                if (email != '') {
                    this.$http({           //调用接口
                        method: 'POST',
                        url: "/JCAccount/ResetpasswordLogin",
                        params: {
                            email: email,
                            oldpassword: oldpassword,
                            newpassword: newpassword
                        }
                    }).then(function (response) {  //接口返回数据
                        //  console.log(response);
                        this.isReset = response.body;
                        if (response.body == true) {
                            this.LoginOut();

                            this.$notify({
                                message: '密码已重置',
                                type: 'success'
                            });
                        }
                        else {
                            this.$notify.error('密码未重置');
                        }
                        console.log(response);
                    }, function (error) {
                        console.log(error);
                    })
                }
            }
            else {
                console.log(email, oldpassword, newpassword);
            }

        },
        mousedownFn: function (e) {
            this.mouseMoveStata = true;
            this.beginClientX = e.clientX;
        }, //按下滑块函数 
        successFunction() {
            $(".handler").removeClass('handler_bg').addClass('handler_ok_bg');
            this.confirmWords = '验证通过'
            $(".drag").css({
                'color': '#fff'
            });
            $(".drag").css({
                'background-color': '#13CE66'
            });
            $(".handler").css({
                'left': this.maxwidth
            });
            $(".drag_bg").css({
                'width': this.maxwidth
            });
            $('body').unbind('mousemove');
            $('body').unbind('mouseup');
            this.confirmSuccess = true;

        }, //验证成功函数
        handleNodeClick(data) {
            console.log(data);
        },

    }
});
nav_langu_box.initNav();
nav_langu_box.initlangubox();