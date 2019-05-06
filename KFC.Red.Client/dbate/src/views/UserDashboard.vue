<template>
  <v-layout>
    <v-flex>
      <Sidebar sm3></Sidebar>
    </v-flex>
    <v-flex sm10>
      <UserProfile v-if="this.$store.getters.getUserPage === 1"></UserProfile>  
      <DeleteAccount v-if="this.$store.getters.getUserPage === 2"></DeleteAccount>  
    </v-flex>
  </v-layout>
</template>

<script>
import Sidebar from '@/components/user-components/UserSidebar'
import UserProfile from '@/components/user-components/UserProfile'
import DeleteAccount from '@/components/user-components/DeleteAccount'
import axios from "axios"
import {URL} from '@/services/ConstUrls'

export default {
  name: 'UserDashboard',
  components: {
      Sidebar,
      UserProfile,
      DeleteAccount
  },
  data: () => ({
      num : 2
  })    
}
</script>

<style>

</style>
