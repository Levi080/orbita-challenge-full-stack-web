<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title class="d-flex align-center">
        <span class="ml-2">Gestão de Alunos</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-img :src="require('@/assets/logo_amaiseducacao.png')"  alt="Logo da Empresa" max-height="50" max-width="130" contain></v-img>
    </v-app-bar>

    <v-navigation-drawer app width="300">
      <v-list-item>
        <v-list-item-title class="text-h6">
          Módulo Acadêmico
        </v-list-item-title>
      </v-list-item>

      <v-divider></v-divider>

      <v-list nav>
        <v-list-item link to="/" color="primary">
          <v-list-item-icon>
            <v-icon>mdi-account</v-icon>
          </v-list-item-icon>
          <v-list-item-title>Alunos</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-main>
    <ToastNotification />
  </v-app>
</template>

<script setup>
import ToastNotification from '@/components/ToastNotification.vue';
</script>