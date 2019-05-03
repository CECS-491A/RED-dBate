<template>
  <v-dialog v-model="thisDialog" max-width="500px">
    <v-card>
      <v-card-title>
        <span>{{ text }}</span>
        <v-spacer></v-spacer>
      </v-card-title>
      <v-card-actions>
        <v-btn color="primary" flat @click="HandleDialog()">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "PopupDialog",
  data: () => ({
    thisDialog: false,
    redirectOnClick: false,
  }),
  props: ["dialog", "text", "redirect", "redirectUrl"],
  created() {
    this.thisDialog = this.$props.dialog;
    this.redirectOnClick = this.$props.redirect;
  },
  methods: {
    HandleDialog(){
      this.thisDialog = false;
      if (this.redirectOnClick){
        window.location.href = decodeURIComponent(this.$props.redirectUrl);
      }
    }
  },
}
</script>