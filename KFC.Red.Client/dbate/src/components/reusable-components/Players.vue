<template>
  <v-list subheader>
  <v-subheader>uuu</v-subheader>
    <v-list-tile avatar v-for="(user) in users" v-bind:key="user.name">
      <v-list-tile-content>
        <v-list-tile-title v-html="chat.name"></v-list-tile-title>
      </v-list-tile-content>
      <v-list-tile-action>
        <v-icon>user_bubble</v-icon>
      </v-list-tile-action>
    </v-list-tile>
  </v-list>
</template>

<script>
  export default{
    data () {
      return {
        userPlaying: 'users playing'
      }
    },
    created () {
    },
    computed: {
      users () {
      }
    }
  }
</script>