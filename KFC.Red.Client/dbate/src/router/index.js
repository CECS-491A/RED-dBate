import Vue from 'vue'
import Router from 'vue-router'
import Chat from '@/views/Chat'
import FAQ from '@/views/FAQ'
import Home from '@/views/Home'
import Login from '@/views/Login'
import Lobby from '@/views/Lobby'
import Waitingroom from '@/views/Waitingroom'
import AdminDashboard from '@/views/AdminDashboard'
import UserDashboard from '@/views/UserDashboard'
import DecideWinner from '@/views/DecideWinner'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/home',
      name: 'Home',
      component: Home
    },
    {
      //path: '/chat',
      path: '/chat/:id',
      name: 'Chat',
      component: Chat
    },
    {
      path: '/waitingroom/:id',
      name: 'Waitingroom',
      component: Waitingroom
    },
    {
      path: '/faq',
      name: 'FAQ',
      component: FAQ
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/lobby',
      name: 'Lobby',
      component: Lobby
    },
    {
      path: '/admindashboard',
      name: 'AdminDashboard',
      component: AdminDashboard
    },
    {
      path: '/userdashboard',
      name: 'UserDashboard',
      component: UserDashboard
    },
    {
      path: '/decidewinner/:id',
      name: 'DecideWinner',
      component: DecideWinner
    }
  ]
})
