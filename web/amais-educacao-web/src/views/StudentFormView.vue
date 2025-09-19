<template>
    <v-container>
        <v-card class="pa-4">
            <v-card-title class="headline">
                Cadastro de aluno
            </v-card-title>
            <v-form ref="form" v-model="valid" lazy-validation>
                <v-container>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field v-model="student.name" label="Nome" placeholder="Informe o nome completo"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12">
                            <v-text-field v-model="student.email" label="E-mail" placeholder="Informe apenas um e-mail"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12" >
                            <v-text-field :disabled="isEditing" v-model="student.ra" label="RA" placeholder="Informe o registro acadêmico"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12">
                            <v-text-field :disabled="isEditing" v-model="student.cpf" label="CPF" placeholder="Informe o número do documento"
                                outlined dense required></v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
            </v-form>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="red" @click="cancel" class="ml-2">
                    Cancelar
                </v-btn>
                <v-btn color="primary" @click="save" class="ml-2">
                    Salvar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useStudentStore } from '@/stores/studentStore'; 
import { storeToRefs } from 'pinia';

import { Student } from '@/models/Student'; 

const router = useRouter();
const studentStore = useStudentStore(); 

const { studentSelected } = storeToRefs(studentStore);

const student = ref({ ...Student });
const isEditing = ref(false);

onMounted(() => {
  if (studentSelected.value) {
    student.value = {...studentSelected.value};
    isEditing.value = true;
  }
});

const cancel = () => {
    studentStore.setStudentSelected(null);
    router.push({ name: 'StudentList' });
};

const save = async () => {
    try {
        if (isEditing.value) {
            await studentStore.updateStudent(student.value);
            studentStore.setStudentSelected(null);
        } else {
            await studentStore.createStudent(student.value);
        }
        router.push({ name: 'StudentList' });
    } catch (error) {
        console.error('Erro ao salvar o aluno:', error);
    }
};
</script>