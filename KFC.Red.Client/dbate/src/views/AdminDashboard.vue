<template>
  <v-layout>
    <v-flex>
      <Sidebar sm3></Sidebar>
    </v-flex>
    <v-flex sm10>
      <UAD v-if="this.$store.getters.getAdminPage === 1"></UAD>  
      <QuestionManager v-if="this.$store.getters.getAdminPage === 2"></QuestionManager>  
      <LogManager v-if="this.$store.getters.getAdminPage === 3"></LogManager>  
      <!--<UserManager v-if="this.$store.getters.getAdminPage === 4"></UserManager>-->  
      <Publish v-if="this.$store.getters.getAdminPage === 5"></Publish>  
    </v-flex>
  </v-layout>
</template>

<script>
import Sidebar from '@/components/admin-components/AdminSidebar'
import QuestionManager from '@/components/admin-components/QuestionManagement'
import LogManager from '@/components/admin-components/LogManager'
import Publish from '@/components/admin-components/Publish'
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
      UserManager,
      Publish
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
