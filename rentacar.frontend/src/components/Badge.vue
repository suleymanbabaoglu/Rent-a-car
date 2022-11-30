<template>
  <router-link :to="link" style="text-decoration: none">
    <v-card :color="color">
      <v-card-title> {{ title }} </v-card-title>
      <v-card-text class="badge">
        {{ text }}
      </v-card-text>
    </v-card>
  </router-link>
</template>

<script setup>
defineProps(["color", "title", "text", "link"]);
</script>

<style scoped>
.badge {
  margin-top: 45px;
  width: 100%;
  height: 100px;
  font-size: 30px;
}
</style>
