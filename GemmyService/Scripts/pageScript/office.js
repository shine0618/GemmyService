var office_selectbox = new Vue({
    el: '#office_selectbox',
    data: {
        OfficeTSDeskContent: "",
        Office: "",
        OfficeTODesk: "",
        OfficeTFDesk: "",
        OfficeTTDeskContent: "",
        OfficeTODeskContent: "",
        OfficeTTDesk: "",
        DeskType: "",
        OfficeBenchDeskContent: "",
        OfficeTFDeskContent: "",
        OfficeBenchDesk: "",
        OfficeTSDesk: "",
        name: 'Vue.js',
        OfficeUnopenNotice: "",
        NAVMainPage: "",
        NAVOfficePage: "",
        OfficeHandset: "",
        OfficeHandsetContent: "",
        OfficeControlbox: "",
        OfficeControlboxContent: "",
        MainAllowNotice: "",
        UserLevel: 0,
    },
    // 在 `methods` 对象中定义方法
    methods: {
        initPage: function (event) {
            var code = GetLanguCode();
            this.UserLevel = GetLoginLevel();
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

        open1() {
            this.$message(this.OfficeUnopenNotice);
        },
        toControlbox() {
            if (this.UserLevel >= 1) {
                window.location.href = "/JCSelection/office_Eservice_controlbox";
            }
            else {
                this.$message({
                    type: 'error',
                    message: this.MainAllowNotice
                });
            }
        },
        toHandset() {
            if (this.UserLevel >= 1) {
                window.location.href = "/JCSelection/office_Eservice_handset";
            }
            else {
                this.$message({
                    type: 'error',
                    message: this.MainAllowNotice
                });
            }
        },
        TypeClick(type, mode) {
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/getclick",
                params: {
                    type: type,
                    mode: mode
                }
            }).then(function (response) {  //接口返回数据
                // console.log(response.body);
                window.location = '/JCSelection/OfficeStandards?Type=' + type;
            }, function (error) {
                window.location = '/JCSelection/OfficeStandards?Type=' + type;
            })

        }
    }
})

office_selectbox.initPage();