import {
    faCircleInfo,
    faHouse,
    faRocket
} from '@fortawesome/free-solid-svg-icons';
import BalanceView from './BalanceView';
import NavigatorSection from './NavigatorSection';
import UserView from './UserView';
import NavigatorItem from './NavigatorItem';

export default function AsideMenu() {
    return (
        <aside className="bg-gray-900 w-80 h-screen hidden lg:block fixed shadow-xl rounded-tr-xl rounded-br-xl p-10">
            <UserView />
            <BalanceView />
            <div className="mt-14">
                <NavigatorSection sectionTitle="Início" sectionIcon={faRocket}>
                    <NavigatorItem
                        itemHref="/"
                        itemTitle="Casa"
                        itemIcon={faHouse}
                    />
                    <NavigatorItem
                        itemHref="/"
                        itemTitle="Sobre"
                        itemIcon={faCircleInfo}
                    />
                </NavigatorSection>
            </div>
        </aside>
    );
}
