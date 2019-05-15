<template>
  <v-layout row>
    <v-flex>
        <v-list three-line>
                      <v-list-tile>
            <v-list-tile-action></v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>{{this.Email}}</v-list-tile-title>
              <v-list-tile-sub-title>Email</v-list-tile-sub-title>
            </v-list-tile-content>
          </v-list-tile>

          <v-list-tile>
            <v-list-tile-action></v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>{{this.Name}}</v-list-tile-title>
              <v-list-tile-sub-title>Name</v-list-tile-sub-title>
            </v-list-tile-content>
          </v-list-tile>

          <v-list-tile>
            <v-list-tile-action></v-list-tile-action>

            <v-list-tile-content>
              <v-list-tile-title>{{this.SSOID}}</v-list-tile-title>
              <v-list-tile-sub-title>SSO ID</v-list-tile-sub-title>
            </v-list-tile-content>

          </v-list-tile>
          <v-divider inset></v-divider>
        </v-list>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
    data() {
    return {
        Name: '',
        Email:'',
        SSOID: '',
    }
  }
}
</script>
