<template>
  <v-app
    id="inspire"
  >
    <v-navigation-drawer>

      <v-img :aspect-ratio="16/9" src="https://cdn.vuetifyjs.com/images/parallax/material.jpg">
        <v-layout pa-2 column fill-height class="lightbox white--text">
          <v-spacer></v-spacer>
          <v-flex shrink>
            <div class="subheading">{{name}}</div>
            <div class="body-1">{{this.$store.getters.getEmail}}</div>
          </v-flex>
        </v-layout>
      </v-img>
      <v-list dense>
        <v-list-tile v-for="item in items" :key="item.text" @click="pageVisit(item.num)">
          <v-list-tile-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title>
              {{ item.text }}
            </v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      name: 'Placeholder',
      email: 'Email Placeholder',
      drawer: null,
      items: [
        { icon: 'info', text: 'User Profile', num: 1 },
        //{ icon: 'widgets', text: 'Delete Account', num: 2 }
      ]
    }),
    methods: {
      pageVisit: function(item) {
        if(item === 1){
          this.$store.dispatch('actUserPage', {UserPage: 1})
        }
        if(item === 2){
          this.$store.dispatch('actUserPage', {UserPage: 2})
       }
      }
    }
  }
</script>