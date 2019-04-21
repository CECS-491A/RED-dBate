<template>
  <v-layout row wrap>
    <v-flex sm3 offset-xs1 class="scrollable">
      <h1>Players in the Game</h1>
      <players></players>
    </v-flex>
    <div v-if="loading">
      <CircleLoad :dialog="loading" :text="loadingText"/>
    </div>
  </v-layout>
</template>

<script>
import Loading from '@/components/reusable-components/dialogs/Loading'

export default {
  name: 'Waitingroom',
  components: {
    Loading,
    Players
  },
  data: () => ({
    token: '',
    loading: false,
    loadingText: '',
    validSession: true,
    popupMessage: '',
  }),    
}
</script>

<style>

</style>
