import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import Chat from '@/components/Chat'
import About from '@/components/About'
import Home from '@/components/Home'
import ChatList from '@/components/ChatList'
import ChatCredentials from '@/components/ChatCredentials'
import QuestionManagement from '@/components/QuestionManagement'
import LogManager from '@/components/LogManager'
import Login from '@/components/Login'
import Publish from '@/components/Publish'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/chat',
      name: 'Chat',
      component: Chat
    },
    {
      path: '/chat-cred',
      name: 'ChatCred',
      component: ChatCredentials
    },
    {
      path: '/about',
      name: 'About',
      component: About
    },
    {
      path: '/chat-list',
      name: 'ChatList',
      component: ChatList
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
    }
  ]
})
