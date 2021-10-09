var office_selectbox = new Vue({
    el: '#office_selectbox',
    data: {
        MainConfigurationTool: "",
        MainProductConfigurationTool: "",
        MainProductFiles: "",
        MainMyOrder: "",
        MainAllowNotice: "",
        UserLevel: 0,
        UserEmail: '',
        UserCompanyName: '',
        isorder: false,
        haveorderapply: false,
        dialogorderapply: false,
        dialoghaveorderapply: false,
        orderform: {
            email: '',
            companyname: '',
        },
        formLabelWidth: '120px',
        rules: {
            email: [
                { required: true }
            ],
            company: [
                { required: true }
            ],
        }
    },
    // 在 `methods` 对象中定义方法
    methods: {
        initPage: function (event) {
            var code = GetLanguCode();
            this.UserLevel = GetLoginLevel();
            this.UserEmail = GetLoginUsername();
            $.ajaxSettings.async = false;

            var languText;
            $.getJSON("/resourse/Language/text-" + code + ".json", function (result) {
                languText = result.language;
            });
            $.ajaxSettings.async = true;

            var obj = languText;
            for (var p in obj) {
                // 方法
                if (typeof (obj[p]) == "function") {
                    obj[p]();
                } else {
                    // p 为属性名称，obj[p]为对应属性的值
                    var key = p;
                    var value = obj[p];
                    this.setData(key, value);;
                }
            }
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/getCompanyapply",
                params: {
                    username: this.UserEmail
                }
            }).then(function (response) {  //接口返回数据
                if (response.body == true) {
                    this.haveorderapply = true;
                }
            }, function (error) {
            })
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);
            ////如果需要提交请求,下面这样是不行的,提交的是field字符串
            //$.post('url', { field: val }, function () { });
            ////需要这样
            //var json = {};
            //json[field] = value
            //$.post('url', json, function () { });

        },
        Toconfiguration: function (event) {
            if (this.UserLevel >= 1) {
                window.location.href = "/JCSelection/office_Eservice_test?Type=TS";
            }
            else {
                this.$message({
                    type: 'error',
                    message: this.MainAllowNotice
                });
            }
        },
        Tofiles: function (event) {
            if (this.UserLevel >= 1) {
                window.location.href = "/JCSelection/FileSearch";
            }
            else {
                this.$message({
                    type: 'error',
                    message: this.MainAllowNotice
                });
            }
        },
        ToOrder: function (event) {
            if (this.UserEmail != '' && this.UserEmail != null) {
                this.$http({           //调用接口
                    method: 'GET',
                    url: "/JCSelection/getCompanyName",
                    params: {
                        username: this.UserEmail
                    }
                }).then(function (response) {  //接口返回数据

                    if (response.body.CompanyName == '' || response.body.CompanyName == null) {
                        if (this.haveorderapply == true) {
                            this.dialoghaveorderapply = true;
                        }
                        else {
                            this.dialogorderapply = true;
                            this.orderform.email = this.UserEmail;
                        }

                    }
                    else {
                        if (response.body.isorder == false) {
                            this.$message({
                                type: 'error',
                                message: this.MainAllowNotice
                            });
                        }
                        else {
                            window.location.href = "/JCSelection/orderlist";
                        }
                    }
                    //console.log(response.body);
                }, function (error) {
                    //console.log(error);
                })
            }
            else {
                this.$message({
                    type: 'error',
                    message: this.MainAllowNotice
                });
            }

        },
        addonSubmit(formname) {
            console.log(this.haveorderapply);
            this.$refs[formname].validate((valid) => {
                if (valid) {
                    this.$http({           //调用接口
                        method: 'POST',
                        url: "/JCSelection/addcompanyapply",
                        params: {
                            forminfo: JSON.stringify(this.orderform),
                        }
                    }).then(function (response) {
                        //console.log(response.body);
                        this.isadd = response.body;
                        if (this.isadd == true) {
                            this.$notify({
                                message: '提交成功',
                                type: 'success'
                            });
                            //location.reload();
                        }
                    })


                    //this.$notify({
                    //    message: '提交成功',
                    //    type: 'success'
                    //});

                }
                else {
                    this.$notify.error('缺少内容');

                }
            })
        },
    }
})

office_selectbox.initPage();