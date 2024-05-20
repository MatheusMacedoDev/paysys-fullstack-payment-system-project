'use client';

import { ReactNode, useState } from 'react';
import CommonUserAsideMenu from './components/CommonUserAsideMenu';
import ShopkeeperAsideMenu from './components/ShopkeeperAsideMenu';

interface SignedLayoutProps {
    children: ReactNode;
}

export default function SignedLayout({ children }: SignedLayoutProps) {
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const [userType, setUserType] = useState<
        'Common' | 'Shopkeeper' | 'Administrator'
    >('Shopkeeper');

    return (
        <div className="w-screen min-h-screen">
            {userType === 'Common' && <CommonUserAsideMenu />}
            {userType === 'Shopkeeper' && <ShopkeeperAsideMenu />}

            <main>{children}</main>
        </div>
    );
}
