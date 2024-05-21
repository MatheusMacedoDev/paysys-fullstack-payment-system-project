import Image from 'next/image';

import DesktopMenu from './DesktopMenu';
import MobileMenuButton from '@/components/MobileMenuButton';

export default function Header() {
    return (
        <header className="bg-gray-900 flex justify-between items-center h-16 px-8 lg:px-28 xl:px-48 shadow-md">
            <Image
                src="/paysys-logo.svg"
                alt="Logomarca do PaySys"
                className="w-12"
                width="48"
                height="48"
            />

            <DesktopMenu />

            <MobileMenuButton href="?navigator=true" />
        </header>
    );
}
