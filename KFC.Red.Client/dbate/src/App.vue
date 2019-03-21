<template>
  <v-app>
    <nav-bar />

    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>
import NavBar from '@/components/reusable-components/NavBar.vue'

export default {
  name: 'app',
  components: {
    NavBar
  }
}
</script>

<style>
</style>
