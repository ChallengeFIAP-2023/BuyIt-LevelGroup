package br.com.fiap.domain.repository;

import br.com.fiap.domain.entity.Log;
import br.com.fiap.domain.entity.Pedido;
import jakarta.persistence.EntityManager;
import jakarta.persistence.EntityTransaction;
import java.util.List;
import java.util.Objects;

public class LogRepository implements Repository<Log, Long> {

    private static LogRepository instance;
    private final EntityManager manager;

    private LogRepository(EntityManager manager) {
        this.manager = manager;
    }

    public static synchronized LogRepository getInstance(EntityManager manager) {
        if (instance == null) {
            instance = new LogRepository(manager);
        }
        return instance;
    }

    @Override
    public Log findById(Long id) {
        return manager.find(Log.class, id);
    }

    public Pedido findByIdPedido(Long id) {
        return manager.find(Pedido.class, id);
    }

    @Override
    public List<Log> findAll() {
        return manager.createQuery("FROM Log", Log.class).getResultList();
    }

    @Override
    public Log persist(Log log) {
        EntityTransaction transaction = manager.getTransaction();
        try {
            transaction.begin();
            log.setId_log(null);
            Pedido pedido = findByIdPedido(log.getId_pedido().getId_pedido());
            log.setId_pedido(pedido);
            manager.persist(log);
            transaction.commit();
        } catch (Exception e) {
            if (transaction.isActive()) {
                transaction.rollback();
            }
        }
        return log;
    }

    @Override
    public Log update(Log log) {
        EntityTransaction transaction = manager.getTransaction();
        try {
            transaction.begin();
            Log log_buscado = manager.find(Log.class, log.getId_log());
            if (Objects.nonNull(log_buscado)) {

                // ID_PEDIDO
                if (Objects.nonNull(log.getId_pedido())) {
                    Pedido pedido = findByIdPedido(log.getId_pedido().getId_pedido());
                    log_buscado.setId_pedido(pedido);
                }

                // TIMESTAMP_LOG
                if (log.getTimestamp_log() != null) {
                    log_buscado.setTimestamp_log(log.getTimestamp_log());
                }

                // NM_LOG
                if (log.getNm_log() != null) {
                    log_buscado.setNm_log(log.getNm_log());
                }

                // DS_LOG
                if (log.getDs_log() != null) {
                    log_buscado.setDs_log(log.getDs_log());
                }

                log = manager.merge(log_buscado);
                transaction.commit();
            } else {
                transaction.rollback();
            }
        } catch (Exception e) {
            if (transaction.isActive()) {
                transaction.rollback();
            }
        }
        return log;
    }

    @Override
    public boolean delete(Log log) {
        EntityTransaction transaction = manager.getTransaction();
        try {
            transaction.begin();
            manager.remove(log);
            transaction.commit();
            return true;
        } catch (Exception e) {
            if (transaction.isActive()) {
                transaction.rollback();
            }
            return false;
        }
    }
}