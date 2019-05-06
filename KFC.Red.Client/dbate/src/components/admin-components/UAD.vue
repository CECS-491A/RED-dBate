<template>
    <v-layout row wrap>
        <v-flex xs12>
            <v-toolbar-title>Average succesful login per month vs Total registered users</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <AvgSuccesfulLogin></AvgSuccesfulLogin>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Average session duration per month</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <AvgSession></AvgSession>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Failed Login Attempts vs Successful Login Attempts</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <FailedvsSuccLogin></FailedvsSuccLogin>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Top 5 Average time spent per page of system</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <Top5Avg></Top5Avg>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Top 5 most used feature</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <Top5MostUsed></Top5MostUsed>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Session duration per month over 6 months</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <AvgSessionLine></AvgSessionLine>
        </v-flex>

        <v-flex xs12>
            <v-toolbar-title>Logged in users per month over 6 months</v-toolbar-title>
        </v-flex>
        <v-flex xs12>
            <NumUsersLine></NumUsersLine>
        </v-flex>
    </v-layout>
</template>

<script>
import AvgSession from '@/components/admin-components/charts/bar/AvgSession'
import AvgSuccesfulLogin from '@/components/admin-components/charts/bar/AvgSuccesfulLogin'
import FailedvsSuccLogin from '@/components/admin-components/charts/bar/FailedvsSuccLogin'
import Top5Avg from '@/components/admin-components/charts/bar/Top5Avg'
import Top5MostUsed from '@/components/admin-components/charts/bar/Top5MostUsed'
import AvgSessionLine from '@/components/admin-components/charts/line/AvgSession'
import NumUsersLine from '@/components/admin-components/charts/line/NumUsers'

export default {
  name: 'UAD',
  data(){
      return {
    // instantiating datacollection with null
    datacollection: null
      }
  },
  components: {
    AvgSession,
    AvgSuccesfulLogin,
    FailedvsSuccLogin,
    Top5Avg,
    Top5MostUsed,
    AvgSessionLine,
    NumUsersLine
  },
  computed: {

  }  
}
</script>

<style>

</style>
