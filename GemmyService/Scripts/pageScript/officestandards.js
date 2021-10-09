var type = GetDeskType();
var recommend = GetDeskrecommend();
var domain = GetDeskdomain();
var OfficeStandards = new Vue({
    el: '#OfficeStandards',
    data: {
        OrderValue: "",
        Order: 0,//1正序 2倒序
        domain: domain,
        Type: type,
        recommend: recommend,
        langCode: "",
        deskList: null,
        searchText: "",
        mouse_plan: '',
        DeskConfigurationName: "",
        deskAll: "",
        NewProductName: "",
        JCRecommendName: "",
        MyCollectName: "",
        CustomerName: "",
        t_OfficeStandards_1: "",
        t_OfficeStandards_2: "",

        //------文本----
        deskNewProductNumber: "",
        deskSalesVolume: "",
        deskPrice: "",
        deskStabilityLeave: "",
        deskMaxLoad: "",
        NAVMainPage: "",
        NAVOfficePage: "",
        OfficeStandardsCustomzed: "",
        OfficeStandardsDeleteplansuccessfulnotice: "",
        OfficeStandardsDeleteplanfailnotice: ""
        //------文本 end ----
    },
    watch: {
        OrderValue: function (val) {
            this.getallDesk();
        },
        Order: function (val) {
            this.getallDesk();
        }
    },
    methods: {
        initPage: function (event) {
            var code = GetLanguCode();
            this.langCode = code;
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
                    // console.log('key:' + key + "  value:" + value);
                    this.setData(key, value);;
                }
            }

        },
        getallDesk: function (event) {

            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/GetOfficeStards",
                params: {
                    domain: this.domain,
                    Type: this.Type,
                    recommend: this.recommend,
                    Order: this.Order,
                    OrderValue: this.OrderValue,
                    langCode: this.langCode,
                    searchText: this.searchText,
                }
            }).then(function (response) {  //接口返回数据

                this.deskList = response.body;
                //console.log(response.body);


            }, function (error) {
            })
        },
        orderBtnClick: function (ordervalue) {

            this.OrderValue = ordervalue;
            if (this.Order == 1) {
                this.Order = 2;
            }
            else {
                this.Order = 1;
            }
        },
        Deleteplan: function (id) {
            //console.log(id);
            this.$http({           //调用接口
                method: 'GET',
                url: "/JCSelection/DeleteCustomer",
                params: {
                    id: id,
                }
            }).then(function (response) {  //接口返回数据
                // console.log(response.body);
                if (response.body == true) {
                    this.$notify({
                        message: this.OfficeStandardsDeleteplansuccessfulnotice,
                        type: 'success'
                    });
                    location.reload();
                }

                else {
                    this.$notify.error(this.OfficeStandardsDeleteplanfailnotice);
                }
            }, function (error) {
            })
        },
        setData: function (field, val) {
            this.$set(this.$data, field, val);//vue 设定值
        },
    }
})

//$(".service-sidebar__category-list li a").each(function (v, elm) {
//    var $a = $(this);

//    if ($a.data('anchor') == recommend) {
//        $a.addClass("changeFont");
//    }
//});

//语言加载
OfficeStandards.initPage();
OfficeStandards.getallDesk();
