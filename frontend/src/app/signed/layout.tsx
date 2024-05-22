'use client';

import { ReactNode, useState } from 'react';
import CommonUserAsideMenu from './components/CommonUserAsideMenu';
import ShopkeeperAsideMenu from './components/ShopkeeperAsideMenu';
import AdministratorAsideMenu from './components/AdministratorAsideMenu';
import MobileHeader from './components/MobileHeader';
import AsideMobileModal from './modals/AsideMobileModal';

interface SignedLayoutProps {
    children: ReactNode;
}

export default function SignedLayout({ children }: SignedLayoutProps) {
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const [userType, setUserType] = useState<
        'Common' | 'Shopkeeper' | 'Administrator'
    >('Common');

    return (
        <div className="w-screen min-h-screen">
            <MobileHeader />
            <div className="flex">
                {userType === 'Common' && (
                    <>
                        <AsideMobileModal>
                            <CommonUserAsideMenu isMobile={true} />
                        </AsideMobileModal>
                        <CommonUserAsideMenu isMobile={false} />
                    </>
                )}
                {userType === 'Shopkeeper' && (
                    <>
                        <AsideMobileModal>
                            <ShopkeeperAsideMenu isMobile={true} />
                        </AsideMobileModal>
                        <ShopkeeperAsideMenu isMobile={false} />
                    </>
                )}
                {userType === 'Administrator' && (
                    <>
                        <AsideMobileModal>
                            <AdministratorAsideMenu isMobile={true} />
                        </AsideMobileModal>
                        <AdministratorAsideMenu isMobile={false} />
                    </>
                )}

                <main className="w-full h-screen overflow-scroll flex flex-col items-center p-6 lg:p-10">
                    {children}
                </main>
            </div>
        </div>
    );
}
