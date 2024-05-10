import Footer from '@/components/Footer';
import Header from '@/components/Header';
import { ReactNode } from 'react';

interface UnsignedLayoutProps {
    children: ReactNode;
}

export default function UnsignedLayout({ children }: UnsignedLayoutProps) {
    return (
        <div className="flex flex-col min-h-screen">
            <Header />

            <main className="flex-1 flex-col">{children}</main>

            <Footer />
        </div>
    );
}
