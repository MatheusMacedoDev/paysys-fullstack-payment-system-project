import { z } from 'zod';

export const makePaymentSchema = z.object({
    paymentAmount: z.string(),
    paymentType: z.string(),
    paymentDescription: z.string(),
    paymentReceiver: z.string()
});

export type MakePaymentData = z.infer<typeof makePaymentSchema>;
