<template>
    <v-container class="mx-auto" style="max-width: 800px;">
        <v-card class="pa-4 px-10">
            <v-card-title class="headline">
                Cadastro de aluno
            </v-card-title>
            <v-form ref="form" v-model="valid" lazy-validation>
                <v-row>
                    <v-col cols="12">
                        <v-text-field
                            v-model="student.name"
                            label="Nome"
                            placeholder="Informe o nome completo"
                            outlined
                            dense
                            required
                            :rules="[v => !!v || 'O nome é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                        <v-text-field
                            v-model="student.email"
                            label="E-mail"
                            placeholder="Informe apenas um e-mail"
                            outlined
                            dense
                            required
                            :rules="[
                                v => !!v || 'O e-mail é obrigatório',
                                v => /.+@.+\..+/.test(v) || 'O e-mail deve ser válido'
                            ]"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                        <v-text-field
                            :disabled="isEditing"
                            v-model="student.ra"
                            label="RA"
                            placeholder="Informe o registro acadêmico"
                            outlined
                            dense
                            required
                            :rules="[
                                v => !!v || 'O RA é obrigatório',
                                v => /^\d+$/.test(v) || 'O RA deve conter apenas números',
                                v => v > 0 || 'O RA deve ser um número positivo',
                            ]"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                        <v-text-field
                            :disabled="isEditing"
                            v-model="formattedCpf"
                            label="CPF"
                            placeholder="Informe o número do documento"
                            outlined
                            dense
                            required
                            :rules="[
                                v => !!v || 'O CPF é obrigatório',
                                v => v.length === 14 || 'O CPF deve conter 11 dígitos'
                            ]"
                        ></v-text-field>
                    </v-col>
                </v-row>
            </v-form>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="red" variant="elevated" @click="cancel" class="ml-2">
                    <v-icon left>mdi-cancel</v-icon>
                    Cancelar
                </v-btn>
                <v-btn color="primary" variant="elevated" @click="save" class="ml-2">
                    <v-icon left>mdi-content-save</v-icon>
                    Salvar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import { useRouter } from 'vue-router';
import { useStudentStore } from '@/stores/studentStore';
import { storeToRefs } from 'pinia';

import { Student } from '@/models/Student';

const router = useRouter();
const studentStore = useStudentStore();
const { studentSelected } = storeToRefs(studentStore);
const form = ref(null);
const valid = ref(true);

const student = ref({ ...Student });
const isEditing = ref(false);

const formattedCpf = computed({
  get() {
    const value = student.value.cpf;
    if (!value) return '';
    return value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4');
  },
  set(newValue) {
    student.value.cpf = newValue.replace(/\D/g, '');
  }
});

onMounted(() => {
    if (studentSelected.value) {
        student.value = { ...studentSelected.value };
        isEditing.value = true;
    }
});

const cancel = () => {
    studentStore.setStudentSelected(null);
    router.push({ name: 'StudentList' });
};

const save = async () => {
    const { valid } = await form.value.validate();
    if (valid) {
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
    }
};
</script>