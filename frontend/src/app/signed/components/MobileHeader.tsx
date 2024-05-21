import MobileMenuButton from '@/components/MobileMenuButton';
import UserView from './UserView';

export default function MobileHeader() {
    return (
        <header className="px-8 py-3 flex lg:hidden items-center justify-between shadow-lg">
            <UserView size="small" />
            <MobileMenuButton href="?signed-menu=true" />
        </header>
    );
}
