//var type = GetDeskType();
var OfficeStandards = new Vue({
    el: '#OfficeStandards',
    data: {
        isAble: false,
        options: [{
            value: 'DXF2D',
            label: 'DXF2D'
        },
        {
            value: 'CREO5',
            label: 'CREO5'
        },
        {
            value: 'SOLIDWORKS',
            label: 'SOLIDWORKS'
        },
        {
            value: 'DWG2D',
            label: 'DWG2D'
        },
        {
            value: 'PDFDATASHEET',
            label: 'PDF'
        },
        {
            value: '3DSTUDIOMAX',
            label: '3DS'
        },
        {
            value: 'STEP-2.14',
            label: 'STEP'
        },
        {
            value: 'OBJFILE',
            label: 'OBJ'
        }],
        format: '',
        download_xml: '',
        loading: false,
        filename: '',
        dialogVisible_partDetail: false,
        centerDialogVisible: false,
        list: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11],
        colorConfirm: '#FF0000',
        selectStep: 's1',//选择的步骤
        deskType: "",
        IsShowDesktop: false,
        search1_column: '',//筛选的正装

        defaultWidth: 0,
        defaultHeight: 0,
        frameWidth: 0,
        frameHeight: 0,
        framesmallHeight: 0,
        framebigHeight: 650,
        framesmallWidth: 1080,
        framesbigWidth: 1800,

        list_column: null,
        list_column_count: 0,
        select_column: "",
        select_columnMode: "",
        mouse_column: "",
        cc_column: "",

        list_frame: null,
        list_frame_count: 0,
        select_frame: "",
        select_frameMode: "",
        mouse_frame: "",
        fc_frame: "",
        list_foot: null,
        list_foot_count: 0,
        select_foot: "",
        select_footMode: "",
        mouse_foot: "",
        tfc_foot: "",
        list_SideBracket: null,
        list_SideBracket_count: 0,
        select_SideBracket: "",
        select_SideBracketMode: "",
        mouse_SideBracket: "",
        spc_SideBracket: "",
        list_ControlBox: null,
        list_ControlBox_count: 0,
        select_ControlBox: "",
        select_ControlBoxMode: "",
        mouse_ControlBox: "",
        controller_ControlBox: "",
        list_HandSet: null,
        list_HandSet_count: 0,
        select_HandSet: "",
        select_HandSetMode: "",
        mouse_HandSet: "",
        hc_HandSet: "",
        list_Powercable: null,
        list_Powercable_count: 0,
        select_Powercable: "",
        select_PowercableMode: "",
        mouse_Powercable: "",

        list_Color: null,
        list_Color_count: 0,
        select_Color: "",
        select_ColorMode: "",
        colour_color: "",
        of_deskboard: "",
        pos1_value: "",
        pos2_value: "",
        url_text: "",
        T_Product_office_desk: null,
        T_Product_office_desk_detail: null,
        productGuid: '',

        //text
        select_text: "",//请选择
        text_customer_1: "",
        text_customer_2: "",
        text_customer_3: "",
        text_customer_4: "",
        text_customer_42_1: "",
        text_customer_42_2: "",
        text_customer_42_3: "",
        text_customer_423: "",
        text_customer_5: "",
        text_customer_6: "",
        text_customer_7: "",
        text_customer_8: "",
        text_customer_9: "",
        text_customer_10: "",
        text_customer_11: "",
        text_customer_12: "",
        text_customer_13: "",
        text_customer_14: "",



        NAVMainPage: "",
        CustomPage: "",
        CustomConfigurationListInfo: "",
        CustomSelectFrame: "",
        CustomSelectFoot: "",
        CustomSelectSideBracket: "",
        CustomSelectControlbox: "",
        CustomSelectHandSet: "",
        CustomSelectPowerCable: "",
        CustomSelectColor: "",
        CustomConfiguration: "",
        CustomResultCount: "",
        CustomInputName: "",
        CustomSelectFrameWidth: "",
        CustomSelectColumnHeight: "",
        CustomColumnNum: "",
        CustomFrameNum: "",
        CustomFootNum: "",
        CustomSidebracketNum: "",
        CustomColorNum: "",
        CustomControlboxNum: "",
        CustomHandsetNum: "",
        CustomPowerCableNum: "",
        CustomWidthLength: "",
        CustomHeightLength: "",
        CustomShowBoard: "",
        CustomNextButton: "",
        CustomSaveConfigurationButton: "",
        CustomSelectColumnNotice: "",
        CustomAddConfirm: "",
        CustomAddNotice: "",
        CustomAddConfirmButton: "",
        CustomAddCancelButton: "",
        CustomAddSuccessNotice: "",
        text_customer_text1: "",
        CustomSelectFootNotice: "",
        CustomAddConfigNameNotice: "",
        CustomAddConfigRedirectNotice: "",
        CustomAddConfigChangeColumnNotice: "",
        CustomAddConfigChangePartsNotice: "",
        MyCollectName: "",
        custmerName: "",//客户命名方案
        ControlBox_c1: "",//控制器筛选
        CustomreturnButton: "",
        Downloadlabel: "",
        Downloadbutton: "",
        detailModel: {
            imgurl: "",
            mode: "",
            des: [],
            ColumnWithFoot: "",
            ColumnWithFrame: "",
            FrameWithSideBracket: "",

        },

        value: 0,
        },
watch: {
    select_column: function (val) {

    },
    select_frame: function (val) {

    },



},
mounted() {
    window.setloadingjs = this.setloading
},
methods: {
    //保存配置
    saveConfigurations: function (event) {

        if (this.custmerName == "") {
            this.selectStep = "s7";
            this.$message({
                type: 'info',
                message: this.CustomAddConfigNameNotice
            });
            return;
        }


        this.$confirm(this.CustomAddConfirm, this.CustomAddNotice, {
            confirmButtonText: this.CustomAddConfirmButton,
            cancelButtonText: this.CustomAddCancelButton,

        }).then(() => {

            this.$http({           //调用接口
                method: 'POST',
                url: "/JCSelection/saveConfigurations",
                params: {

                    select_columnMode: this.select_columnMode,
                    select_frameMode: this.select_frameMode,
                    select_footMode: this.select_footMode,
                    select_SideBracketMode: this.select_SideBracketMode,
                    select_ColorMode: this.select_ColorMode,
                    select_ControlBoxMode: this.select_ControlBoxMode,
                    select_HandSetMode: this.select_HandSetMode,
                    select_PowercableMode: this.select_PowercableMode,
                    frameWidth: this.frameWidth,
                    frameHeight: this.frameHeight,
                    langCode: this.langCode,
                    Type: "TS",
                    custmerName: this.custmerName,//客户命名方案
                }
            }).then(function (response) {  //接口返回数据
                if (response.body.type == "true") {
                    //this.$message({
                    //    type: 'success',
                    //    message: this.CustomAddSuccessNotice
                    //});
                    this.$confirm(this.CustomAddConfigRedirectNotice, this.CustomAddSuccessNotice, {
                        confirmButtonText: this.CustomAddConfirmButton,
                        cancelButtonText: this.CustomAddCancelButton,

                    }).then(() => {
                        window.location = "/JCSelection_Customer/personal";
                    }).catch(() => {
                        return;
                    });


                }
                else {
                    //失败
                    this.$message({
                        type: 'error',
                        message: response.body.msg
                    });
                }
            }, function (error) {
                //console.log(error);
            })


        }).catch(() => {
            return;
        });




    },


    handleClick(tab, event) {
        // console.log(tab);


    },
    initPage: function (event) {
        var code = GetLanguCode();
        this.langCode = code;
        $.ajaxSettings.async = false;
        var level = GetLoginLevel();
        if (level < 1) {
            window.location.href = "/JCSelection/main";
        }
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
        var url = "https://jiecang-embedded.partcommunity.com/3d-cad-models/sso/jc36tViewBag-%E5%8D%87%E9%99%8D%E6%A1%8C-%E6%8D%B7%E6%98%8C?info=jiecang%2Flifting_table%2Fjc36ts_asmtab.prj&cwid=6919&showPortlets=preview&hidePortlets=navigation&languageIso=" + this.langCode;
        var i = '<iframe scrolling="no"  id="shjahs"  alt=""  src = ""/>';

        $('#iDisplayBox').append(i);
        //$("#shjahs").attr({
        //    "src": url + "&languageIso=" + this.langCode
        //});
    },


    getpartDetail: function (partType, Mode) {

        this.$http({           //调用接口
            method: 'GET',
            url: "/JCSelection/GetPartDetail",
            params: {
                partType: partType,
                Mode: Mode,
                langCode: this.langCode,
            }
        }).then(function (response) {  //接口返回数据

            this.detailModel = response.body;
            //console.log(response.body);
        }, function (error) {
            //console.log(error);
        })

        this.dialogVisible_partDetail = true



    },

    getAllControlBox: function (event) {
        this.$http({           //调用接口
            method: 'GET',
            url: "/JCSelection/GetOfficeControlBox",
            params: {
                
            }
        }).then(function (response) {  //接口返回数据
            this.list_ControlBox = response.body;
            this.list_ControlBox_count = this.list_ControlBox.length;
            console.log(response.body);

        }, function (error) {
            //console.log(error);
        })
    },


    ControlBoxClick: function (id, mode) {
        if (this.select_ControlBox == id) {
            return;
        }
        if (this.select_ControlBox == id) {
            this.select_ControlBox = 0;
            this.select_ControlBoxMode = "";
        }
        else {
            this.select_ControlBox = id;
            this.select_ControlBoxMode = mode;
        }
        this.SetFrame();

    },


    SetFrame: function () {
        // var base = "https://jiecang-embedded.partcommunity.com/3d-cad-models/sso/jcb35n2-controller-jiecang?info=jiecang%2Fcontroller%2F";
        var base = "https://webapi.partcommunity.com/cgi-bin/cgi2pview.exe?cgiaction=preview&part={jiecang/controller/controller_zp.prj}";
        var option = "&firm=jiecang&viewerOptions=%7B%22webglViewerSettings%22%3A%7B%22ColorTL%22%3A%22%23EFF2F6%22%2C%22ColorTR%22%3A%22%23EFF2F6%22%2C%22ColorML%22%3A%22EFF2F6%22%2C%22ColorMR%22%3A%22EFF2F6%22%2C%22ColorBL%22%3A%22%23EFF2F6%22%2C%22ColorBR%22%3A%22%23EFF2F6%22%7D%7D&apikey=e20d66d8bb834f2497a101cff347a2d0";
        var b = ".prj&cwid=6919&showPortlets=preview&hidePortlets=navigation";

        if (this.select_ControlBoxMode != "") {
            this.filename = this.select_ControlBoxMode;

            var src = base + ",{MODEL=" + this.select_ControlBoxMode.toLowerCase() + "}" + option;
            console.log(src);
            //    alert(src);

            $("#shjahs").attr({
                "src": src
            });

        }
        else {
            $("#shjahs").attr({
                "src": ""
            });
        }

        //  console.log(base);





    },
    returnback: function (event) {
        window.location = "/JCSelection/office";
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
    setData: function (field, val) {
        this.$set(this.$data, field, val);//vue 设定值
    },
    getThisDesk: function (productGuid) {
        //获取桌子详细信息 从另外一个标准配置跳转过来
        this.$http({           //调用接口
            method: 'GET',
            url: "/JCSelection/GetOfficeDeskDetail2",
            params: {
                lang: this.langCode,
                productGuid: productGuid,
            }
        }).then(function (response) {  //接口返回数据
            //console.log(response.body);
            var column = "";
            var frame = "";
            var foot = "";
            var control = "";
            var handset = "";
            var side = "";
            var color = "";
            this.T_Product_office_desk = response.body.T_Product_office_desk;
            this.T_Product_office_desk_detail = response.body.T_Product_office_desk_detail;
            //添加到产品配置列表 立柱
            if (this.T_Product_office_desk_detail.T_Part_office_Column != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_Column;
                this.select_column = it.Id;
                this.select_columnMode = it.Mode;
                column = it.Mode;
            }
            //添加到产品配置列表
            if (this.T_Product_office_desk_detail.T_Part_office_Foot != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_Foot;
                this.select_foot = it.Id;
                this.select_footMode = it.Mode;
                foot = it.Mode;
            }
            //添加到产品配置列表
            if (this.T_Product_office_desk_detail.T_Part_office_Frame != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_Frame;
                this.select_frame = it.Id;
                this.select_frameMode = it.Mode;
                frame = it.Mode;
            }
            //添加到产品配置列表
            if (this.T_Product_office_desk_detail.T_Part_office_SideBracket != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_SideBracket;
                this.select_SideBracket = it.Id;
                this.select_SideBracketMode = it.Mode;
                side = it.Mode;
            }
            //添加到产品配置列表
            if (this.T_Product_office_desk_detail.T_Part_office_ControlBox != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_ControlBox;
                this.select_ControlBox = it.Id;
                this.select_ControlBoxMode = it.Mode;
                control = it.Mode;
            }
            //手控器
            if (this.T_Product_office_desk_detail.T_Part_office_HandSet != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_HandSet;
                this.select_HandSet = it.Id;
                this.select_HandSetMode = it.Mode;
                handset = it.Mode;
            }

            //电源线
            if (this.T_Product_office_desk_detail.T_Part_office_Powercable != null) {
                var it = this.T_Product_office_desk_detail.T_Part_office_Powercable;
                this.select_Powercable = it.Id;
                this.select_PowercableMode = it.Mode;

            }

            if (this.T_Product_office_desk_detail.T_Office_Color != null) {
                var it = this.T_Product_office_desk_detail.T_Office_Color;
                this.select_Color = it.Id;
                this.select_ColorMode = it.ColorName;
                color = it.ColorNumber;
                this.colour_color = it.ColorNumber;
            }

            if (this.T_Product_office_desk_detail.frameWidth != "") {

                this.defaultWidth = this.T_Product_office_desk_detail.frameWidth;
            }
            if (this.T_Product_office_desk_detail.frameHeight != "") {
                this.defaultHeight = this.T_Product_office_desk_detail.frameHeight;
            }
            //this.url_text  = checkProductDetailUrl(column, frame, foot, side, control, handset, color);
            //$("#shjahs").attr({
            //    "src": this.url_text + "&languageIso=" + this.langCode
            //});

            this.SetFrame();

            this.cc_column = column;
            this.fc_frame = frame;
            this.tfc_foot = foot;
            this.spc_SideBracket = side;
            this.controller_ControlBox = control;
            this.hc_HandSet = handset;
            this.colour_color = color;
        }, function (error) {
            //console.log(error);
        })
    },
    order: function (event) {
        if (this.format != '') {
            console.log(this.filename);
            this.loading = true;
            this.isAble = true;
            if (this.filename != '') {
                $.post("https://webapi.partcommunity.com/cgi-bin/cgi2pview.exe", {
                    cgiaction: "download",
                    downloadflags: "ZIP",
                    part: "{jiecang/controller/controller_zp.prj}" + ",{MODEL=" + this.filename + "}",
                    firm: "jiecang",
                    format: this.format,
                    ok_url: "<%download_xml%>", // format of the url to generate
                    ok_url_type: "text", // we want a direct text response (no 302)
                    apikey: "e20d66d8bb834f2497a101cff347a2d0",
                    zipfilename: "Jiecang<%wkbno%>",
                }).done(function (data) {
                    download_xml = data; // get the file name for polling
                    checkFile(); // start polling
                });
            }
            else {

            }
        }
    },
    setloading() {
        this.loading = false;
        this.isAble = false;
    }
}
    })
//语言加载
OfficeStandards.initPage();
OfficeStandards.getAllControlBox();