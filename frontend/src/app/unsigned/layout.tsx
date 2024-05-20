import Footer from '@/components/Footer';
import { ReactNode } from 'react';
import AsideNavigatorModal from './modals/AsideNavigatorModal';
import Header from './components/Header';

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
