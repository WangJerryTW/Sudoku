import Vue from 'vue'
import Router from 'vue-router'
import Index from './views/Index.vue'
import Sudoku from './views/Sudoku.vue'
import Admin from './views/Admin.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'index',
      component: Index
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    },
    {
      path: '/admin',
      name: 'admin',
      component: Admin
    },
    {
      path: '/sudoku/:id',
      name: 'Sudoku',
      component: Sudoku
    }
  ]
})
