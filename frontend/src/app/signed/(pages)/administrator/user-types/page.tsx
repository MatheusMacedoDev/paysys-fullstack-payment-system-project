'use client';

import Form from '@/components/Form';
import {
    UserTypeData,
    useUserTypeForm
} from '@/validations/userTypeValidations';
import { FormProvider } from 'react-hook-form';

export default function UserTypePage() {
    const userTypeForm = useUserTypeForm();

    const { handleSubmit } = userTypeForm;

    function createUserType(data: UserTypeData) {
        console.log(data);
    }

    return (
        <>
            <section className="w-full h-[600px] flex items-center justify-center">
                <FormProvider {...userTypeForm}>
                    <Form.Container
                        onSubmit={handleSubmit(createUserType)}
                        sendButtonTitle="Cadastrar"
                    >
                        <Form.Title>Tipos de Usuários</Form.Title>
                        <Form.InputsGroup>
                            <Form.Input placeholder="Nome" name="name" />
                        </Form.InputsGroup>
                    </Form.Container>
                </FormProvider>
            </section>
        </>
    );
}
