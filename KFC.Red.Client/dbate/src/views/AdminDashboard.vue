<template>
  <v-layout>
    <v-flex>
      <Sidebar sm3></Sidebar>
    </v-flex>
    <v-flex sm10>
      <UAD v-if="this.$store.getters.getAdminPage === 1"></UAD>  
      <QuestionManager v-if="this.$store.getters.getAdminPage === 2"></QuestionManager>  
      <LogManager v-if="this.$store.getters.getAdminPage === 3"></LogManager>  
      <UserManager v-if="this.$store.getters.getAdminPage === 4"></UserManager>  
    </v-flex>
  </v-layout>
</template>

<script>
import Sidebar from '@/components/Sidebar'
import QuestionManager from '@/components/admin-components/QuestionManagement'
import LogManager from '@/components/admin-components/LogManager'
import UAD from '@/components/admin-components/UAD'
import UserManager from '@/components/admin-components/UserManager'
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
  name: 'AdminDashboard',
  components: {
      Sidebar,
      QuestionManager,
      LogManager,
      UAD,
      UserManager
  },
  data: () => ({
      num : 2
  }),
  computed: {

  }    
}
</script>

<style>

</style>
