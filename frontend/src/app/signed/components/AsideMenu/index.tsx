import UserView from './UserView';

export default function AsideMenu() {
    return (
        <aside className="bg-gray-900 w-80 h-screen hidden lg:block fixed shadow-xl rounded-tr-xl rounded-br-xl p-10">
            <UserView />
        </aside>
    );
}
