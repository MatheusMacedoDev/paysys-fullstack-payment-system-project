import {
    faChartSimple,
    faFileInvoiceDollar,
    faMoneyBillWave
} from '@fortawesome/free-solid-svg-icons';
import AsideMenu from './AsideMenu';
import { Navigator } from './AsideMenu/Navigator';

export default function ShopkeeperAsideMenu() {
    return (
        <AsideMenu>
            <Navigator.Section
                sectionTitle="Recebimentos"
                sectionIcon={faMoneyBillWave}
            >
                <Navigator.Item
                    itemTitle="Gráfico Informativo"
                    itemIcon={faChartSimple}
                    itemHref="/"
                />
                <Navigator.Item
                    itemTitle="Histórico"
                    itemIcon={faFileInvoiceDollar}
                    itemHref="/"
                />
            </Navigator.Section>
        </AsideMenu>
    );
}
