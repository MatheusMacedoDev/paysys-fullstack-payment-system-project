'use client';

import { faEnvelope, faKey } from '@fortawesome/free-solid-svg-icons';
import Form from '@/components/Form';

import { FormProvider, useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { MakeLoginData, makeLoginSchema } from '@/validations/loginValidations';

export default function Login() {
    const makeLoginForm = useForm<MakeLoginData>({
        resolver: zodResolver(makeLoginSchema)
    });

    const { handleSubmit } = makeLoginForm;

    function makeLogin(data: MakeLoginData) {
        console.log(JSON.stringify(data));
    }

    return (
        <Form.Background>
            <FormProvider {...makeLoginForm}>
                <Form.Container
                    sendButtonTitle="Entrar"
                    onSubmit={handleSubmit(makeLogin)}
                >
                    <Form.Title>Entre na sua conta</Form.Title>
                    <Form.InputsGroup>
                        <Form.Input
                            name="email"
                            placeholder="E-mail"
                            icon={faEnvelope}
                        />
                        <Form.Input
                            name="password"
                            placeholder="Senha"
                            icon={faKey}
                        />
                    </Form.InputsGroup>
                </Form.Container>
            </FormProvider>
        </Form.Background>
    );
}
