<template>
  <v-container style="width: 100%; margin-top: 100px">
    <v-card>
      <v-layout>
        <!-- <v-system-bar color="deep-purple darken-3"></v-system-bar> -->

        <v-app-bar color="primary" prominent>
          <v-app-bar-nav-icon
            variant="text"
            @click.stop="drawer = !drawer"
          ></v-app-bar-nav-icon>
          <router-link to="/" style="text-decoration: none;color: white"> <v-icon icon="mdi-home" /> </router-link>
          <v-toolbar-title>{{ route.name }}</v-toolbar-title>

          <v-spacer></v-spacer>


        </v-app-bar>

        <v-navigation-drawer v-model="drawer" location="top" temporary>
          <v-list>
            <v-list-item> <RouterLink to="/">Home</RouterLink></v-list-item>
            <v-list-item> <RouterLink to="/car">Cars</RouterLink></v-list-item>
            <v-list-item>
              <RouterLink to="/customer">Customers</RouterLink></v-list-item
            >
            <v-list-item>
              <RouterLink to="/rental">Rentals</RouterLink></v-list-item
            >
          </v-list>
        </v-navigation-drawer>
      </v-layout>
      <RouterView />
    </v-card>
  </v-container>
</template>
<script setup>
import { RouterLink, RouterView, useRoute } from "vue-router";
const route = useRoute();
import { ref } from "vue";
const drawer = ref(false);
</script>
<style scoped>
.v-card {
  overflow: visible !important;
}
</style>
