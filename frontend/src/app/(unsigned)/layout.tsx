import Footer from '@/components/Footer';
import Header from '@/components/Header';
import { ReactNode, Suspense } from 'react';
import AsideNavigatorModal from './modals/AsideNavigatorModal';

interface UnsignedLayoutProps {
    children: ReactNode;
}

export default function UnsignedLayout({ children }: UnsignedLayoutProps) {
    return (
        <>
            <AsideNavigatorModal />

            <div className="flex flex-col min-h-screen">
                <Header />

                <main className="flex-1 flex-col">{children}</main>

                <Footer />
            </div>
        </>
    );
}
