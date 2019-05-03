import Vue from 'vue'
import Router from 'vue-router'
import Chat from '@/views/Chat'
import About from '@/views/About'
import Home from '@/views/Home'
import Login from '@/views/Login'
import Publish from '@/views/Publish'
import Lobby from '@/views/Lobby'
import Waitingroom from '@/views/Waitingroom'
import AdminDashboard from '@/views/AdminDashboard'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
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
      path: '/about',
      name: 'About',
      component: About
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/publish',
      name: 'Publish',
      component: Publish
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
    }
  ]
})
