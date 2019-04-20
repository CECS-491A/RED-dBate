<template>
  <v-dialog v-model="dialog" hide-overlay persistent width="300">
    <v-card color="primary" dark>
      <v-card-text>
        {{ text }}
        <v-progress-linear indeterminate color="white" class="mb-0"></v-progress-linear>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "Loading",
  props: ["dialog", "text"],
  watch: {
    dialog(val) {
      if (val) setTimeout(() => this.$emit("stopLoading", false), 1000);
      else return;
    }
  }
};
</script>

