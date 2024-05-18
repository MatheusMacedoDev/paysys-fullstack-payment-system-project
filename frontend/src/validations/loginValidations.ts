import { z } from 'zod';

export const makeLoginSchema = z.object({
    email: z
        .string()
        .email('Formato de e-mail inválido.')
        .min(1, 'O e-mail é obrigatório.'),
    password: z.string().min(1, 'A senha é obrigatória.')
});

export type MakeLoginData = z.infer<typeof makeLoginSchema>;
