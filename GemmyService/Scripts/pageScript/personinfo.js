var email = GetLoginUsername();
var name = GetLoginCustomname();
var OfficeStandards = new Vue({
    el: '#OfficeStandards',
    data() {
        return {
            isadd: false,
            ruleForm: {
                Email: email,
                Name: name,
                Sex: '',
                Telephone: '',
                CompanyName: '',
                CompanyStreet: '',
                CompanyLocation: '',
                CompanyNation: '',
                CompanyWebsite: ''
            },
            rules: {
                Email: [
                    { message: '请输入活动名称', trigger: 'blur' }
                ],
                Name: [
                    { message: '请选择活动区域', trigger: 'blur' }
                ],
                Sex: [
                    { required: true, message: '请填写性别', trigger: 'blur' }
                ],
                Telephone: [
                    { required: true, message: '请填写联系方式', trigger: 'blur' }
                ],
                CompanyName: [
                    { required: true, message: '请填写公司名称', trigger: 'blur' }
                ],
                CompanyStreet: [
                    { required: true, message: '请填写公司地址', trigger: 'blur' }
                ],
                CompanyLocation: [
                    { required: true, message: '请填写公司详细地址', trigger: 'blur' }
                ],
                CompanyNation: [
                    { required: true, message: '请填写公司地区', trigger: 'blur' }
                ],
                CompanyWebsite: [
                    { required: true, message: '请填写公司官网', trigger: 'blur' }
                ],
            }
        };
    },
    methods: {
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.$http({           //调用接口
                        method: 'POST',
                        url: "/JCAccount/AddCompanyInfo",
                        params: {
                            forminfo: JSON.stringify(this.ruleForm),
                        }
                    }).then(function (response) {
                        this.isadd = response.body;
                        //console.log(this.ruleForm);
                        //console.log(JSON.stringify(this.ruleForm));
                        //console.log(response.body);
                        if (this.isadd == true) {
                            this.$notify({
                                message: '提交成功',
                                type: 'success'
                            });
                            window.location = "/JCSelection/main";
                        }
                    })
                }
                else {
                    this.$notify.error('缺少内容');
                    return false;
                }
            });
        },
        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
        initPages: function (e) {
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCAccount/GetCompanyInfo",
                params: {
                    email: email,
                    name: name,
                }
            }).then(function (response) {
                this.ruleForm = response.body;
                //console.log(response.body);
            })
        }
    }
}
)
OfficeStandards.initPages();