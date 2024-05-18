import { z } from 'zod';

export const baseRegisterSchema = z.object({
    userType: z.string(),
    email: z
        .string()
        .min(1, 'O e-mail é obrigatório.')
        .email('Insira um e-mail válido.'),
    phoneNumber: z.string().min(11, 'Insira um telefone válido'),
    password: z.string().min(1, 'A senha é obrigatória.'),
    confirmPassword: z.string().min(1, 'A confirmação da senha é obrigatória')
});

export type BaseRegisterData = z.infer<typeof baseRegisterSchema>;

export const commonUserRegisterSchema = baseRegisterSchema.merge(
    z.object({
        name: z.string().min(1, 'O nome é obrigatório.'),
        cpf: z.string().min(11, 'Insira um CPF válido.')
    })
);

export type CommonUserRegisterData = z.infer<typeof commonUserRegisterSchema>;

export const shopkeeperRegisterSchema = baseRegisterSchema.merge(
    z.object({
        fancyName: z.string().min(1),
        companyName: z.string().min(1),
        cnpj: z.string().min(14)
    })
);

export type ShopkeeperRegisterData = z.infer<typeof shopkeeperRegisterSchema>;
