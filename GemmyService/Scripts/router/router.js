//
import Vue from '../vue'
import VueRouter from 'vue-router'
import ManagePage from '../JCManage/ManagePage'
import test1 from '../JCManage/test1'

Vue.use(VueRouter)

export default new VueRouter({
    routes: [
        {
            path: '/test1',
            name: 'test1',
            componet: test1
        }
    ]
})