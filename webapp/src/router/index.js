import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/Index'
import Sudoku from '@/components/Sudoku'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index
    },
    {
      path: '/sudoku/:id',
      name: 'Sudoku',
      component: Sudoku
    }
  ]
})
