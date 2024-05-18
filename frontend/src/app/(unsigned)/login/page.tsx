'use client';

import Form from '@/components/Form';
import { faEnvelope, faKey } from '@fortawesome/free-solid-svg-icons';
import { zodResolver } from '@hookform/resolvers/zod';
import { FormProvider, useForm } from 'react-hook-form';
import { z } from 'zod';

const makeLoginSchema = z.object({
    email: z
        .string()
        .email('Formato de e-mail inválido.')
        .min(1, 'O e-mail é obrigatório.'),
    password: z.string().min(1, 'A senha é obrigatória.')
});

type MakeLoginData = z.infer<typeof makeLoginSchema>;

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
