import type { Metadata } from 'next';
import { Raleway } from 'next/font/google';
import './globals.css';

import { config } from '@fortawesome/fontawesome-svg-core';
import '@fortawesome/fontawesome-svg-core/styles.css';
config.autoAddCss = false;

const raleway = Raleway({
    subsets: ['latin'],
    display: 'swap',
    variable: '--font-raleway'
});

export const metadata: Metadata = {
    title: 'PaySys - Sistema de Pagamento',
    description:
        'É um sistema de pagamento que conecta pessoas a negócios e a outras pessoas.'
};

export default function RootLayout({
    children
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="pt-BR">
            <body className={raleway.className}>{children}</body>
        </html>
    );
}
