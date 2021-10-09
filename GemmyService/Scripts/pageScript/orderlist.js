var orderlist = new Vue({
    el: "#orderlist",
    data: {
        NAVMainPage: '',
        CustomPage: '',
        partType: '',
        Nature: '',
        Mode: '',
        UserEmail: '',
        value1: '',
        UserCompanyName: '',
        dateStart: '',
        dateEnd: '',
        ordersystem: '',
        orderdate: '',
        orderto: '',
        orderstartdate: '',
        orderenddate: '',
        orderlookbtn: '',
    },
    watch: {
        value1() {
            //console.log(this.value1);
            if (this.value1.length >= 2) {
                this.dateStart = this.value1[0];
                this.dateEnd = this.value1[1];
            }
            //console.log(this.dateStart);
            //console.log(this.dateEnd);
        }
    },
    methods: {
        initPage: function (event) {
            var code = GetLanguCode();
            this.langCode = code;
            $.ajaxSettings.async = false;
            //var level = GetLoginLevel();
            //if (level < 1) {
            //    window.location.href = "/JCSelection/main";
            //}
            this.UserEmail = GetLoginUsername();
            if (this.UserEmail == null || this.UserEmail == '') {
                window.location.href = "/JCSelection/main";
            }
            this.UserCompanyName = GetLoginCompanyName();
            if (this.UserCompanyName == '') {
                window.location.href = "/JCSelection/main";
            }
            //var url = "http://61.175.247.114:7081/JC_SD/Index?I_STATE=%E5%85%A8%E9%83%A8&I_STATE_prdo=%E5%85%A8%E9%83%A8&type=overview&I_JHJQ_S=2021-09-09&I_JHJQ_E=2021-09-09&I_XSJQ_S=&I_XSJQ_E=&S_ZYD=1200&I_VBELN=&S_ZKHMC=" + this.UserCompanyName + "&S_ZYWY=&S_ZSYB=&S_ZQY=";
            //$("#shjahs").attr({
            //    "src": url
            //});
            //console.log(url);
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
                    // console.log('key:' + key + "  value:" + value);
                    this.setData(key, value);
                }
            }
            var i = '<iframe scrolling="yes"  id="shjahs"  alt=""  src = ""/>';
            $('#asas').append(i);
            var date = new Date();
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            var strDate = date.getDate();
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            this.dateStart = year + "-" + month + "-" + strDate;
            this.dateEnd = year + "-" + month + "-" + strDate;
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);//vue 设定值
        },
        ordersearch() {
            var url = "http://61.175.247.114:7081/JC_SD/Index?I_STATE=%E5%85%A8%E9%83%A8&I_STATE_prdo=%E5%85%A8%E9%83%A8&type=overview";
            if (this.dateStart != "") {
                url += "&I_JHJQ_S=" + this.dateStart;
            }
            if (this.dateEnd != "") {
                url += "&I_JHJQ_E=" + this.dateEnd;
            }
            url += "&I_XSJQ_S=&I_XSJQ_E=&S_ZYD=1200&I_VBELN=&S_ZKHMC=" + this.UserCompanyName + "&S_ZYWY=&S_ZSYB=&S_ZQY=";
            $("#shjahs").attr({
                "src": url
            });
        }
    },
})
orderlist.initPage();