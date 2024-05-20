import { ReactNode } from 'react';
import CommonUserAsideMenu from './components/CommonUserAsideMenu';

interface SignedLayoutProps {
    children: ReactNode;
}

export default function SignedLayout({ children }: SignedLayoutProps) {
    const userType: 'Common' | 'Shopkeeper' | 'Administrator' = 'Common';

    return (
        <div className="w-screen min-h-screen">
            {userType === 'Common' && <CommonUserAsideMenu />}

            <main>{children}</main>
        </div>
    );
}
