import Vue from 'vue'
import Router from 'vue-router'
import Chat from '@/components/Chat'
import About from '@/components/About'
import Home from '@/components/Home'
import QuestionManagement from '@/components/QuestionManagement'
import LogManager from '@/components/LogManager'
import Login from '@/components/Login'
import Publish from '@/components/Publish'
import Lobby from '@/components/Lobby'
import Waitingroom from '@/components/Waitingroom'

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
      path: '/questmanagement',
      name: 'QuestManagement',
      component: QuestionManagement
    },
    {
      path: '/logmanager',
      name: 'LogManager',
      component: LogManager
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
    }
  ]
})
